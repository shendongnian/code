    using (var fbd = new FolderBrowserDialog())
    {
        if (fbd.ShowDialog() == DialogResult.OK)
        {
            foreach (var file in Directory.GetFiles(fbd.SelectedPath,
                "*.png", SearchOption.AllDirectories)
            {
                // this catches things like *.png1 or *.pngp
                // not that they'd ever exist; but they may
                if (Path.GetExtension(file).Length > 4) { continue; }
                var pictureBox = new PictureBox();
                pictureBox.Load(file);
                // set its location here
                this.Controls.Add(pictureBox);
            }
        }
    }
