                if (SelectMedia.ShowDialog() == DialogResult.OK)
                {
                    if (SelectMedia.FilterIndex == 1)
                    {
                        PictureViewer picture = new PictureViewer();
                        picture.SetPicture(SelectMedia.FileName);
                        FileInfo path = new FileInfo(SelectMedia.FileName);
                        FileNameLabel.Text = path;
                        picture.Show();
                    }
                }
