    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var fileNames = new List<DownloadModel>
                {
                    new DownloadModel
                    {
                        FileName = "File1"
                    }, 
                    new DownloadModel
                    {
                        FileName = "File2"
                    }, 
                    new DownloadModel
                    {
                        FileName = "File3"
                    }
                };
    
                listBox1.ItemsSource = fileNames;
            }
    
            private void ButtonCancel_Click(object sender, RoutedEventArgs e)
            {
                var myButton = sender as Button;
                if (myButton.Tag == null)
                {
                    MessageBox.Show("Tag value was null.");
                }
                else
                {
                    MessageBox.Show(string.Format("File name is {0}", myButton.Tag));
                }
            }
        }
    
        public class DownloadModel
        {
            public string FileName { get; set; }
        }
