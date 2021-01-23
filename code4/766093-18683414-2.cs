        public ListForm()
        {
            InitializeComponent();
            // path to images and roms
            const string location = @"d:\temp\roms\";
            // bind image list with list view
            listViewControl.SmallImageList = imageList;
            // get all images without extension
            var images = System.IO.Directory.GetFiles(location, "*.gif").Select(f => System.IO.Path.GetFileNameWithoutExtension(f)).ToList();
            // get all roms without extension
            var zips = System.IO.Directory.GetFiles(location, "*.zip").Select(f => System.IO.Path.GetFileNameWithoutExtension(f)).ToList();
            // find all entries (images and zips) that have the same name
            var matching = images.Intersect(zips);
            var imageIndex = 0;
            // fill image list and list view at the same time and store rom location
            foreach (var match in matching)
            {
                // path to file without extension
                var file = System.IO.Path.Combine(location, match);
                // add image to image list
                imageList.Images.Add(match, Bitmap.FromFile(string.Format("{0}.gif", file)));
                // create list view item 
                var lvi = new ListViewItem(match);
                // and set list view item image
                lvi.ImageIndex = imageIndex;
                // store rom location
                lvi.Tag = string.Format("{0}.zip", file);
                imageIndex++;
                // and show
                listViewControl.Items.Add(lvi);
            }
        }
        private void listViewControl_MouseClick(object sender, MouseEventArgs e)
        {
            // when user clicks an item, fetch the rom location and go
            var item = listViewControl.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                var pathToRom = item.Tag as string;
                // do something with rom ...
            }
        }
