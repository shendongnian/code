            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|All files (*.*)|*.*";
            save.FilterIndex = 2;
            save.RestoreDirectory = true;
            save.OverwritePrompt = true;
            save.ShowHelp = true;
            save.AddExtension = true;
            if ((save.ShowDialog() == DialogResult.OK))  
                if (Path.GetExtension(save.FileName).ToLower() == ".bmp")
                    pictureBox1.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                else if (Path.GetExtension(save.FileName).ToLower() == ".jpg")
                    pictureBox1.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (Path.GetExtension(save.FileName).ToLower() == ".gif")
                    pictureBox1.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                else if (Path.GetExtension(save.FileName).ToLower() == ".png")
                    pictureBox1.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                else if (Path.GetExtension(save.FileName).ToLower() == ".tif")
                    pictureBox1.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                else
                    MessageBox.Show("File Save Error.");
