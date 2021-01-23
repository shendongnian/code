    Microsoft.Win32.OpenFileDialog  fd = new Microsoft.Win32.OpenFileDialog ();
        if (fd.ShowDialog() == true)
        {
            Stream stream = File.OpenRead(fd.FileName);
            byte[] binaryImage = new byte[stream.Length];
            stream.Read(binaryImage, 0, (int)stream.Length);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(stream);
            _business.PersonalPhoto = binaryImage;
        }
