    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace Blend
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void OnSelectionChanged(object sender, RoutedEventArgs e)
            {
                TableRowCount.Text = GetSelectedParagraphs(RichTextBox.Document, RichTextBox.Selection).Count.ToString();
                SelectionText.Text = RichTextBox.Selection.Text;
            }
    
            public static List<TableRow> GetSelectedParagraphs(FlowDocument document, TextSelection selection)
            {
                return document.Blocks
                    .OfType<Table>()
                    .SelectMany(x => x.RowGroups)
                    .SelectMany(x => x.Rows)
                    .Where(w => selection.Contains(w.ContentStart))
                    .ToList();
            }
        }
    }
