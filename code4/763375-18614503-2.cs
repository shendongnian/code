    public class PrintHelper
    {
        private static Canvas PrintingRoot { get; set; }
    
        private static string TextToBePrint { get; set; }
    
        private static string PrintingFileName { get; set; }
    
        internal static int currentPreviewPage;
    
        private static PrintDocument printDocument = null;
    
        private static IPrintDocumentSource printDocumentSource = null;
    
        internal static List<PageLoadState> printPreviewPages = new List<PageLoadState>();
    
        private const double ApplicationContentMarginLeft = 0.075;
    
        private const double ApplicationContentMarginTop = 0.03;
    
        private static bool ShowText
        {
            get { return ((int)imageText & (int)DisplayContent.Text) == (int)DisplayContent.Text; }
        }
    
        internal static DisplayContent imageText = DisplayContent.TextAndImages;
    
        private static void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
        {
            PrintTask printTask = e.Request.CreatePrintTask(PrintingFileName, sourceRequested => sourceRequested.SetSource(printDocumentSource));
        }
    
        private static void RegisterForPrinting()
        {
            // Create the PrintDocument.
            printDocument = new PrintDocument();
    
            // Save the DocumentSource.
            printDocumentSource = printDocument.DocumentSource;
    
            // Add an event handler which creates preview pages.
            printDocument.Paginate += CreatePrintPreviewPages;
    
            // Add an event handler which provides a specified preview page.
            printDocument.GetPreviewPage += GetPrintPreviewPage;
    
            // Add an event handler which provides all final print pages.
            printDocument.AddPages += AddPrintPages;
    
    
            // Create a PrintManager and add a handler for printing initialization.
            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested += PrintTaskRequested;
        }
    
        private static void UnregisterForPrinting()
        {
            // Set the instance of the PrintDocument to null.
            printDocument = null;
    
            // Remove the handler for printing initialization.
            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested -= PrintTaskRequested;
        }
    
        private static event EventHandler pagesCreated;
    
        private static void CreatePrintPreviewPages(object sender, PaginateEventArgs e)
        {
            // Clear the cache of preview pages 
            printPreviewPages.Clear();
    
            // Clear the printing root of preview pages
            PrintingRoot.Children.Clear();
    
            // This variable keeps track of the last RichTextBlockOverflow element that was added to a page which will be printed
            RichTextBlockOverflow lastRTBOOnPage;
    
            // Get the PrintTaskOptions
            PrintTaskOptions printingOptions = ((PrintTaskOptions)e.PrintTaskOptions);
    
            // Get the page description to deterimine how big the page is
            PrintPageDescription pageDescription = printingOptions.GetPageDescription(0);
    
            // We know there is at least one page to be printed. passing null as the first parameter to
            // AddOnePrintPreviewPage tells the function to add the first page.
            lastRTBOOnPage = AddOnePrintPreviewPage(null, pageDescription);
    
            // We know there are more pages to be added as long as the last RichTextBoxOverflow added to a print preview
            // page has extra content
            while (lastRTBOOnPage.HasOverflowContent)
            {
                lastRTBOOnPage = AddOnePrintPreviewPage(lastRTBOOnPage, pageDescription);
            }
    
            if (pagesCreated != null)
                pagesCreated.Invoke(printPreviewPages, null);
    
            // Report the number of preview pages created
            printDocument.SetPreviewPageCount(printPreviewPages.Count, PreviewPageCountType.Intermediate);
        }
    
        private static void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            Interlocked.Exchange(ref currentPreviewPage, e.PageNumber - 1);
    
            PageLoadState pageLoadState = printPreviewPages[e.PageNumber - 1];
    
            if (!pageLoadState.Ready)
            {
                // Notify the user that some content is not available yet
                // Apps may also opt to don't show preview untill everything is complete and just use await IsReadyAsync
                //rootPage.NotifyUser("Image loading not complete, previewing only text", NotifyType.ErrorMessage);
            }
    
            // Set the preview even if images failed to load properly
            printDocument.SetPreviewPage(e.PageNumber, pageLoadState.Page);
        }
    
        private static void AddPrintPages(object sender, AddPagesEventArgs e)
        {
            // Loop over all of the preview pages and add each one to  add each page to be printied
            for (int i = 0; i < printPreviewPages.Count; i++)
            {
                // We should have all pages ready at this point...
                printDocument.AddPage(printPreviewPages[i].Page);
            }
    
            // Indicate that all of the print pages have been provided
            printDocument.AddPagesComplete();
        }
    
        private static RichTextBlockOverflow AddOnePrintPreviewPage(RichTextBlockOverflow lastRTBOAdded, PrintPageDescription printPageDescription)
        {
            // Create a cavase which represents the page 
            Canvas page = new Canvas();
            page.Width = printPageDescription.PageSize.Width;
            page.Height = printPageDescription.PageSize.Height;
    
            PageLoadState pageState = new PageLoadState(page, printPreviewPages.Count);
            pageState.ReadyAction = async (pageNumber, currentPage) =>
            {
                // Ignore if this is not the current page
                if (Interlocked.CompareExchange(ref currentPreviewPage, currentPreviewPage, pageNumber) == pageNumber)
                {
                    await Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        //await new Windows.UI.Popups.MessageDialog("Content loaded").ShowAsync();
                        printDocument.SetPreviewPage(pageNumber + 1, currentPage);
                    });
                }
            };
    
            // Create a grid which contains the actual content to be printed
            Grid content = new Grid();
    
            // Get the margins size
            // If the ImageableRect is smaller than the app provided margins use the ImageableRect
            double marginWidth = Math.Max(printPageDescription.PageSize.Width - printPageDescription.ImageableRect.Width,
                                        printPageDescription.PageSize.Width * ApplicationContentMarginLeft * 2);
    
            double marginHeight = Math.Max(printPageDescription.PageSize.Height - printPageDescription.ImageableRect.Height,
                                            printPageDescription.PageSize.Height * ApplicationContentMarginTop * 2);
    
            // Set content size based on the given margins
            content.Width = printPageDescription.PageSize.Width - marginWidth;
            content.Height = printPageDescription.PageSize.Height - marginHeight;
    
            // Set content margins
            content.SetValue(Canvas.LeftProperty, marginWidth / 2);
            content.SetValue(Canvas.TopProperty, marginHeight / 2);
    
            // Add the RowDefinitions to the Grid which is a content to be printed
            RowDefinition rowDef = new RowDefinition();
    
            rowDef.Height = new GridLength(2.5, GridUnitType.Star);
            content.RowDefinitions.Add(rowDef);
            rowDef = new RowDefinition();
            rowDef.Height = new GridLength(3.5, GridUnitType.Star);
            content.RowDefinitions.Add(rowDef);
            rowDef = new RowDefinition();
            rowDef.Height = new GridLength(1.5, GridUnitType.Star);
            content.RowDefinitions.Add(rowDef);
    
            // If lastRTBOAdded is null then we know we are creating the first page. 
            bool isFirstPage = lastRTBOAdded == null;
    
            FrameworkElement previousLTCOnPage = null;
            RichTextBlockOverflow rtbo = new RichTextBlockOverflow();
            // Create the linked containers and and add them to the content grid
            if (isFirstPage)
            {
                // The first linked container in a chain of linked containers is is always a RichTextBlock
                RichTextBlock rtbl = new RichTextBlock();
                rtbl.SetValue(Grid.RowProperty, 0);
                rtbl = AddContentToRTBl(rtbl);
                int a = rtbl.Blocks.Count();
                rtbl.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                content.Children.Add(rtbl);
    
                // Save the RichTextBlock as the last linked container added to this page
                previousLTCOnPage = rtbl;
            }
            else
            {
                // This is not the first page so the first element on this page has to be a
                // RichTextBoxOverflow that links to the last RichTextBlockOverflow added to
                // the previous page.
                rtbo = new RichTextBlockOverflow();
                rtbo.SetValue(Grid.RowProperty, 0);
                content.Children.Add(rtbo);
    
                // Keep text flowing from the previous page to this page by setting the linked text container just
                // created (rtbo) as the OverflowContentTarget for the last linked text container from the previous page 
                lastRTBOAdded.OverflowContentTarget = rtbo;
    
                // Save the RichTextBlockOverflow as the last linked container added to this page
                previousLTCOnPage = rtbo;
            }
    
            if (ShowText)
            {
                // Create the next linked text container for on this page.
                rtbo = new RichTextBlockOverflow();
                rtbo.SetValue(Grid.RowProperty, 1);
    
                // Add the RichTextBlockOverflow to the content to be printed.
                content.Children.Add(rtbo);
    
                // Add the new RichTextBlockOverflow to the chain of linked text containers. To do this we much check
                // to see if the previous container is a RichTextBlock or RichTextBlockOverflow.
                if (previousLTCOnPage is RichTextBlock)
                    ((RichTextBlock)previousLTCOnPage).OverflowContentTarget = rtbo;
                else
                    ((RichTextBlockOverflow)previousLTCOnPage).OverflowContentTarget = rtbo;
    
                // Save the last linked text container added to the chain
                previousLTCOnPage = rtbo;
    
                // Create the next linked text container for on this page.
                rtbo = new RichTextBlockOverflow();
                rtbo.SetValue(Grid.RowProperty, 2);
                content.Children.Add(rtbo);
    
                // Add the new RichTextBlockOverflow to the chain of linked text containers. We don't have to check
                // the type of the previous linked container this time because we know it's a RichTextBlockOverflow element
                ((RichTextBlockOverflow)previousLTCOnPage).OverflowContentTarget = rtbo;
            }
            // We are done creating the content for this page. Add it to the Canvas which represents the page
            page.Children.Add(content);
    
            // Add the newley created page to the printing root which is part of the visual tree and force it to go
            // through layout so that the linked containers correctly distribute the content inside them.
            PrintingRoot.Children.Add(page);
            PrintingRoot.InvalidateMeasure();
            PrintingRoot.UpdateLayout();
    
            // Add the newley created page to the list of pages
            printPreviewPages.Add(pageState);
    
            // Return the last linked container added to the page
            return rtbo;
        }
    
        private static RichTextBlock AddContentToRTBl(RichTextBlock rtbl)
        {
            // Create a Run and give it content
            Run run = new Run();
            run.Text = TextToBePrint;
    
            // Create a paragraph, set it's property according to text box.
            Paragraph para = new Paragraph();
            para.FontSize = 20;
    
            para.Inlines.Add(run);
            // Add the paragraph to the blocks collection of the RichTextBlock
            rtbl.Blocks.Add(para);
            return rtbl;
        }
    
        public static async Task ShowPrintUIAsync(Canvas PrintingCanvas, string textToBePrint, string FileName)
        {
            if (PrintingCanvas == null)
                throw new NullReferenceException("Canvas must be present in XAML. It is for showing print preview.");
    
            if (string.IsNullOrWhiteSpace(FileName))
                throw new ArgumentException("The file name for the document which is going to be print must not be empty or only white space.");
    
            PrintingRoot = PrintingCanvas;
            TextToBePrint = textToBePrint;
            PrintingFileName = FileName;
            UnregisterForPrinting();
            RegisterForPrinting();
            await PrintManager.ShowPrintUIAsync();
        }
    }
    
    public class PageLoadState
    {
        private CountdownEvent loadingElements;
    
        public Action<int, UIElement> ReadyAction { get; set; }
    
        private int pageNumber;
    
        private UIElement page;
    
        public UIElement Page
        {
            get { return page; }
        }
    
        public PageLoadState(UIElement page, int pageNumber)
        {
            this.page = page;
            this.pageNumber = pageNumber;
            loadingElements = new CountdownEvent(0);
        }
    
        private void SetElementComplete()
        {
            loadingElements.Signal();
        }
    
        public void ListenForCompletion(BitmapImage bitmap)
        {
            if (loadingElements.CurrentCount == 0)
            {
                // Event is already signaled. Manually set the count to 1 and "arm" the event.
                loadingElements.Reset(1);
            }
            else
            {
                // AddCount will throw if event is already in signaled state.
                loadingElements.AddCount();
            }
            bitmap.ImageOpened += (s, e) => SetElementComplete();
        }
    
        public bool Ready
        {
            get
            {
                var ready = loadingElements.CurrentCount == 0;
                if (!ready)
                {
                    // A request was made and the content is not ready, serve it once it's complete
                    Task.Run(async () =>
                    {
                        await IsReadyAsync();
                        ReadyAction(pageNumber, page);
                    });
                }
    
                return ready;
            }
        }
    
        public async Task IsReadyAsync()
        {
            await Task.Run(() => { loadingElements.Wait(); });
        }
    }
    
    internal enum DisplayContent : int
    {
        Text = 1,
    
        Images = 2,
    
        TextAndImages = 3
    }
