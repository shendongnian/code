     void cameracapturetask_Completed(object sender, PhotoResult e)
            {
                try
                {
                    if (e.TaskResult == TaskResult.OK)
                    {
                        BitmapImage bmp = new BitmapImage();
                        bmp.SetSource(e.ChosenPhoto);
                        img.Source = bmp;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
