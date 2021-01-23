        private string ImageToBase64String(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        private void SaveButton()
        {
            string Pic = ImageToBase64String(PicBox.Image);
            OleDbCommand PicSave = new OleDbCommand("INSERT INTO Picture(ID,PICTURE)VALUES(" + PicId.Text + ",'" + Pic + "')", con);
            con.Open();
            var SaveValue = PicSave.ExecuteNonQuery();
            if (SaveValue > 0)
            {
                MessageBox.Show("Record Saved", "Information");
                ValueClear();
            }
            else
                MessageBox.Show("Rocord Not Saved", "Erro Msg");
            con.Close();
        }
