    private void buttonCompress_Click(object sender, EventArgs e)
    {
        if ((folderBrowserDialog1.ShowDialog() == DialogResult.OK) && (saveFileDialog1.ShowDialog() == DialogResult.OK))
        {
            buttonCompress.Enabled = false;
            String DirectoryToZip = folderBrowserDialog1.SelectedPath;
            String ZipFileToCreate = saveFileDialog1.FileName;
            // fire off zipping job in a background thread
            Task.Factory.StartNew(() => StartZipping(DirectoryToZip, ZipFileToCreate), TaskCreationOptions.LongRunning);
        }
    }
    private object StartZipping(string DirectoryToZip, string ZipFileToCreate)
    {
        using (ZipFile zip = new ZipFile())
        {
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
            zip.SaveProgress += SaveProgress;
            zip.StatusMessageTextWriter = System.Console.Out;
            zip.AddDirectory(DirectoryToZip); // recurses subdirectories
            zip.Save(ZipFileToCreate);
        }
    }
