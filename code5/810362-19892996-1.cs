    namespace ListBox
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
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.DefaultExt = ".mp3";
                openfile.Filter = "mp3 | *.mp3";
                Nullable<bool> result = openfile.ShowDialog();
                if (result == true)
                {
                    String file = openfile.FileName;
                    //FileInfo fileinfo = new FileInfo(file);
    
                    SongList.Items.Add(file); //(fileinfo.Name);
                }
            }
             private void Selection_Changed(object sender, EventArgs e)
            {
                  var myListBox = sender as ListBox;
                  var file = myListBox.items[myListBox.SelectedIndex];
                  var fi = new FileInfo(file);
                  pathLabel.Content = fi.DirectoryName;
            }
        }
    }
