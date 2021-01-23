    using System.Text;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void OnFlowDocumentLoaded(object sender, RoutedEventArgs e)
            {
                var paginator = (DynamicDocumentPaginator)((IDocumentPaginatorSource)this.flowDocument).DocumentPaginator;
    
                var text = new StringBuilder();
    
                for (int pageNumber = 0; ; ++pageNumber)
                    using(var page = paginator.GetPage(pageNumber))
                    using (var nextPage = paginator.GetPage(pageNumber + 1))
                    {
                        if (page == DocumentPage.Missing)
                            break;
    
                        var startPosition = (TextPointer)paginator.GetPagePosition(page);
                        var endPosition = nextPage == DocumentPage.Missing ? this.flowDocument.ContentEnd : (TextPointer)paginator.GetPagePosition(nextPage);
    
                        var range = new TextRange(startPosition, endPosition);
    
                        text.AppendFormat("Page {0}:", pageNumber + 1).AppendLine();
                        text.AppendLine(range.Text);
                    }
    
                this.outputTextBlock.Text = text.ToString();
            }
        }
    }
