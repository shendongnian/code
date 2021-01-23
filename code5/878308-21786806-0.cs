    Image img = pictureEdit1.EditValue as Image; // or use the PictureEdit.Image property
    using(MemoryStream ms = new MemoryStream()) {
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        byte[] bytes = ms.ToArray();
    }
