    foreach (DataGridViewRow row1 in dgvDisplayTiles.Rows)
    {
        string imgPath;
        imgPath= Path.Combine(Application.StartupPath, row1.Cells[3].Value.ToString());
        Image imageFile = Image.FromFile(imgPath);
        if (imgPath != null)
        {
            //img.Image=imgPath;
            row1.Cells[3].Value = imageFile;
        }
        else
        {
            MessageBox.Show("Invalid Path");
        }
    }
