    private void MethodName()
    {
        string fileReducedDimName = @"c:\pics";
        int i = 0;
        foreach (string file in Directory.GetFiles(fileReducedDimName, "*.jpg"))
        {
                
            //if the file dimensions are big, scale the file down
            using (Image image = Image.FromFile(file))
            {
                using (Bitmap bm = ScaleImage(image))
                {
                    bm.Save(fileReducedDimName + @"\" + i.ToString() + ".jpg", ImageFormat.Jpeg);//error occurs here
                    //this is all redundant code - do not need
                    //Array.Clear(photoByte, 0, photoByte.Length);
                    //bm.Dispose();
                }
            }
            //ResizeImage(file, 50, 50, fileReducedDimName +@"\" + i.ToString()+".jpg");
            i++;
        }
    }
