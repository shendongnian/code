    <StackPanel>            
            <ListBox x:Name="fileList" Height="100" Drop="fileList_Drop" DisplayMemberPath="Name" AllowDrop="True"/>
            <Button Content="Browse" Click="Button_Click"/>
            <Rectangle/>
        </StackPanel>
     public partial class MainWindow : Window
    {
        ObservableCollection<FileInfo> lst = new ObservableCollection<FileInfo>();
        public MainWindow()
        {
            InitializeComponent();
            fileList.ItemsSource = lst;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if ((bool)dlg.ShowDialog())
            {
                FileInfo fi= new FileInfo(dlg.FileName);
                lst.Add(fi);
            }
        }
        private void fileList_Drop(object sender, DragEventArgs e)
        {
            string[] droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            foreach (string droppedFilePath in droppedFilePaths)
            {
                FileInfo fi = new FileInfo(droppedFilePath);
                lst.Add(fi);
            }
        }
    }
