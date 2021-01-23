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
                    FileInfo fileinfo = new FileInfo(file);
    
                    SongList.Items.Add(fileinfo.Name);
                    var pathList = SongList.Tag as List<string>;
                    pathList.Add(fileinfo.DirectoryName);
                    SongList.Tag = pathList;
                }
            }
             private void Selection_Changed(object sender, EventArgs e)
            {
                  var myListBox = sender as ListBox;
                  var myPathList = myListBox.Tag as List<string>;
                  var filePath = myPathList[myListBox.SelectedIndex];
                  pathLabel.Content = filePath;
            }
        }
    }
