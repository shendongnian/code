    protected void btnUploadImg_Click(object sender, EventArgs e)
        {
            Session["Image"] = fulImg.PostedFile;
            Stream fs = fulImg.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            img.ImageUrl = "data:image/png;base64," + base64String;
        }
