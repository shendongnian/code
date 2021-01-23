    public class AudioItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbSange.DisplayMember = "Name";
            var path = @"C:\Programmer\Jukebox\Songs";
            var files = System.IO.Directory.GetFiles(path);
            foreach (var file in files)
            {
                var item = new AudioItem
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(file),
                    Path = file
                };
                this.cbSange.Items.Add(item);
            }
        }
        private void cbSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cbSange.SelectedItem;
            if (selectedItem != null)
            {
                var audioItem = (AudioItem)selectedItem;
                var filePath = audioItem.Path;
                //Use 'filePath' to open the file
            }
        }
    }
