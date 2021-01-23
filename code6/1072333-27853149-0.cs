    private void GetImages()
        {
            DirectoryInfo dir = new DirectoryInfo(@"c:\pics");
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(100, 100);
            this.listView1.LargeImageList = this.imageList1;
            int j = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    //this.imageList1.Images.Add(Image.FromFile(file.FullName));
                    imageList1.Images.Add(file.Name, Image.FromFile(file.FullName));
                    ListViewItem item = new ListViewItem(file.Name);
                    item.Tag = file.Name;
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                    j++;
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
        }
