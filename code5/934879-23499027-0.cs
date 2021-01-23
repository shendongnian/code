    private async void button1_Click(object sender, EventArgs e)
    {
        await LoadAllPics();
    }
    
    private async Task LoadAllPics()
    {
        IEnumerable<string> files = Directory.EnumerateFiles(@"C:\Dropbox\Photos", "*.JPG", SearchOption.AllDirectories);
        await Task.Run(() =>
        {
            foreach(string file in files)
            {  
                Invoke((MethodInvoker)(() => 
                {
                    PictureBox pic = new PictureBox() { Image = Image.FromFile(file) };
                    this.Controls.Add(pic);
                }));
            }
        }
        );
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
    }
