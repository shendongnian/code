    public class itemClass
    {
        public string VideoIcon { get; set; }
        public string VideoFile { get; set; }
        public string CreatedDateTime { get; set; }
    }
     ListViewItem item = new ListViewItem();           
     this.listView.Items.Add(new itemClass { VideoIcon = @"E:\Self\ref.png", VideoFile = "filename", CreatedDateTime = "18/18/18" });
