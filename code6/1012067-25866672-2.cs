            _filenames = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(@"E:\mypics");
            foreach (FileInfo file in dir.GetFiles())
            {
                var image = Image.FromFile(file.FullName);
                _filenames.Add(file.Name);
                imageList1.Images.Add(image);
            }
            listView1.View = View.LargeIcon;
            imageList1.ImageSize = new Size(100, 150);
            listView1.LargeImageList = imageList1;
            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                var item = new ListViewItem();
                item.ImageIndex = i;
                item.Text =_filenames[i];
                listView1.Items.Add(item);
            }
        }
