      private void BtnCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png|gif(*.gif)|*.gif|bmp(*.bmp)|*.bmp|All Files(*.*)|*.*";
            if (OD.ShowDialog() == true)
            {
                using (Stream stream = OD.OpenFile())
                {
                    bitCoder = BitmapDecoder.Create(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                    ImgFoto.Source = bitCoder.Frames[0];
                }
                System.IO.FileStream fs = new System.IO.FileStream(OD.FileName, System.IO.FileMode.Open);
                foto = new byte[Convert.ToInt32(fs.Length.ToString())];
                fs.Read(foto, 0, foto.Length);
            }
        }
