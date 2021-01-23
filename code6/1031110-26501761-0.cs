    var view = objToPrint as ListView;
    if (view != null)
      PrintExtensions.PrintPreview(view);
    else
    {
      var grid = objToPrint as DataGrid;
      if (grid != null)
        PrintExtensions.PrintPreview(grid);                                            
    } 
    public static class PrintExtensions
    {
      private static FixedDocument ToFixedDocument(UIElement element, PrintDialog dialog)
      {
            var capabilities = dialog.PrintQueue.GetPrintCapabilities(dialog.PrintTicket);
            var pageSize = new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight);
            var extentSize = new Size(capabilities.PageImageableArea.ExtentWidth,capabilities.PageImageableArea.ExtentHeight);
    
            var fixedDocument = new FixedDocument();
            element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            element.Arrange(new Rect(new Point(0, 0), element.DesiredSize));
            double totalHeight = element.DesiredSize.Height;
            double yOffset = 0d;
            while (yOffset < totalHeight)
            {
                var brush = new VisualBrush(element)
                                        {
                                            Stretch = Stretch.None,
                                            AlignmentX = AlignmentX.Left,
                                            AlignmentY = AlignmentY.Top,
                                            ViewboxUnits = BrushMappingMode.Absolute,
                                            TileMode = TileMode.None,
                                            Viewbox = new Rect(0, yOffset, extentSize.Width, extentSize.Height)
                                        };
                var pageContent = new PageContent();
                var page = new FixedPage();
                ((IAddChild)pageContent).AddChild(page);
                fixedDocument.Pages.Add(pageContent);
                page.Width = pageSize.Width;
                page.Height = pageSize.Height;
                var canvas = new Canvas();
                FixedPage.SetLeft(canvas, capabilities.PageImageableArea.OriginWidth);
                FixedPage.SetTop(canvas, capabilities.PageImageableArea.OriginHeight);
                canvas.Width = extentSize.Width;
                canvas.Height = extentSize.Height;
                canvas.Background = brush;
                page.Children.Add(canvas);
                yOffset += extentSize.Height;
            }
            return fixedDocument;
        }
        private static ListView ToPrintFriendlyGrid(ListView source)
        {
            var listView = new ListView {ItemsSource = source.ItemsSource};
            listView.SetValue(ListViewPagingBehavior.EnablePagingProperty, false);
            listView.Items.Filter = null;
            ScrollViewer.SetVerticalScrollBarVisibility(listView, ScrollBarVisibility.Hidden);
            ScrollViewer.SetHorizontalScrollBarVisibility(listView, ScrollBarVisibility.Hidden);
            var gridView = (GridView)source.View;
            var newGridView = new GridView();
            double width = 0;
            foreach (var viewColumn in gridView.Columns)
            {
                var column = viewColumn;
                if (column != null)
                {
                    var columnType = column.GetType();
                    var newColumn = (GridViewColumn) Activator.CreateInstance(columnType);
                    var objPropertiesArray = columnType.GetProperties();
                    foreach (PropertyInfo info in objPropertiesArray)
                    {
                        var pin = columnType.GetProperty(info.Name);
                        if (pin != null)
                        {
                            if (pin.CanWrite)
                            {
                                object obj = info.GetValue(column, null);
                                pin.SetValue(newColumn, obj, null);
                            }
                        }
                    }
                    width += column.Width;
                    newGridView.Columns.Add(newColumn);
                }
            }
            listView.Width = width;
            var dialog = new PrintDialog();
            double d = Math.Round(dialog.PrintableAreaHeight / 21, 2); // elementi contenuti in una pagina
            double e = Math.Round(listView.Items.Count / d, 2); // numero di pagine ... anche se attualmente c'è qualche problema di impaginazione
            if (Math.Truncate(e) == 0)
                e = .95;
            listView.Height = dialog.PrintableAreaHeight * e;
            listView.View = newGridView;
            return listView;
        }
        private static DataGrid ToPrintFriendlyGrid(DataGrid source)
        {
            var newGridView = new DataGrid {ItemsSource = source.ItemsSource};
            ScrollViewer.SetVerticalScrollBarVisibility(newGridView, ScrollBarVisibility.Hidden);
            ScrollViewer.SetHorizontalScrollBarVisibility(newGridView, ScrollBarVisibility.Hidden);
            double width = 0;
            foreach (DataGridColumn gridColumn in source.Columns)
            {
                var column = gridColumn;
                if (column != null)
                {
                    Type columnType = column.GetType();
                    var newColumn = (DataGridColumn) Activator.CreateInstance(columnType);
                    PropertyInfo[] objPropertiesArray = columnType.GetProperties();
                    foreach (PropertyInfo info in objPropertiesArray)
                    {
                        PropertyInfo pin = columnType.GetProperty(info.Name);
                        if (pin != null)
                        {
                            if (pin.CanWrite)
                            {
                                object obj = info.GetValue(column, null);
                                pin.SetValue(newColumn, obj, null);
                            }
                        }
                    }
                    width += column.ActualWidth;
                    newGridView.Columns.Add(newColumn);
                }
            }
            newGridView.Width = width;
            var dialog = new PrintDialog();
            double d = Math.Round(dialog.PrintableAreaHeight / 21, 2); // elementi contenuti in una pagina
            double e = Math.Round(newGridView.Items.Count / d, 2); // numero di pagine ... anche se attualmente c'è qualche problema di impaginazione
            if (Math.Truncate(e) == 0)
                e = .95;
            newGridView.Height = dialog.PrintableAreaHeight * e;           
            return newGridView;
        }
        public static void PrintPreview(ListView source)
        {
            var window = new Window {Title = "Print Preview"};
            var documentViewer = new DocumentViewer
                                                {
                                                    Document =
                                                        ToFixedDocument(ToPrintFriendlyGrid(source), new PrintDialog())
                                                };
            window.Content = documentViewer;
            window.ShowDialog();
        }
        public static void Print(ListView source, bool showDialog)
        {
            var dialog = new PrintDialog();
            bool? dialogResult = showDialog ? dialog.ShowDialog() : true;
            if (dialogResult == true)
            {
                var viewer = new DocumentViewer
                                            {
                                                Document = ToFixedDocument(ToPrintFriendlyGrid(source), dialog)
                                            };
                dialog.PrintDocument(viewer.Document.DocumentPaginator, null);
            }
        }
        public static void PrintPreview(DataGrid source)
        {
            var window = new Window { Title = "Print Preview" };
            var documentViewer = new DocumentViewer
            {
                Document =
                    ToFixedDocument(ToPrintFriendlyGrid(source), new PrintDialog())
            };
            window.Content = documentViewer;
            window.ShowDialog();
        }
        public static void Print(DataGrid source, bool showDialog)
        {
            var dialog = new PrintDialog();
            bool? dialogResult = showDialog ? dialog.ShowDialog() : true;
            if (dialogResult == true)
            {
                var viewer = new DocumentViewer
                {
                    Document = ToFixedDocument(ToPrintFriendlyGrid(source), dialog)
                };
                dialog.PrintDocument(viewer.Document.DocumentPaginator, null);
            }
        }        
    }
