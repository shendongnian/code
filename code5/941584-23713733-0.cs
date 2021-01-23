    private int picture_Click(object sender, EventArgs e)
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
    
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pict.Add(new Bitmap(dlg.FileName));
                        return 1;
                    }
                }
            }
    
