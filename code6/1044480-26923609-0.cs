    PictureBox[] pb = { pictureBoxHouse1, pictureBoxHouse2, pictureBoxHouse3,
                        pictureBoxHouse4, pictureBoxHouse5, pictureBoxHouse6 };
    using (MySqlDataReader dr = cmd.ExecuteReader())
    {
        int i = 0;
        while (dr.Read())
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (dr["HousePicture"] != DBNull.Value)
                {
                    byte[] image = (byte[])dr["HousePicture"];
                    stream.Write(image, 0, image.Length);
                    Bitmap bitmap = new Bitmap(stream);
                    pb[i].Image = bitmap;
                }
            }
            i++;
        }
    }
