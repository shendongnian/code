    // get the registry-key
    RegistryKey wp = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);
            
    // get the wallpaper filename
    string sFileName = (string)wp.GetValue("Wallpaper");
            
    // finally load the image into picture box
    pictureBox1.Image = Image.FromFile(sFileName);
