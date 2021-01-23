    Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);
    string wallpaper = key.GetValue("Wallpaper").ToString();
    PictureBox pbox = new PictureBox();
    pbox.Image = new Bitmap(wallpaper);
    this.Controls.Add(pbox);
