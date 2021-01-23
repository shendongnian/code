       var filename = TagLib.File.Create(file);
                            if (filename.Tag.Pictures.Length >= 1)
                            {
                                var bin = (byte[])(filename.Tag.Pictures[0].Data.Data);
                                if (bin.Length > 0)
                                {
                                    Images = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(800, 800, null, IntPtr.Zero);
                                    PreviewPictureBox.Image = Images;
                                    PreviewPictureBox.Image.Save("C:/Users/v-manshr/Desktop/MyMusicPlayer/MyMusicPlayer/AlbumImage/"+filename.Tag.Album+".jpg");
                                    PreviewPictureBox.Visible = false;
                                }
                            }
