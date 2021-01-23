        int height=0,width = 0;
        ImageFormat i;
        foreach (string pic in files)
        {
            using (Image temp = Image.FromFile(pic))
            {
                if (whatisformat() != null)
                    i = whatisformat();
                else
                    i = GetImageFormat(temp);
                if (sizeselected()!=-1)
                {
                    height = sizeselected();
                    width = getwidth(height);
                }
                else
                {
                    width = temp.Width;
                    height = temp.Height;
                }
                Formatresizesave(temp, i, height, width, destination,Path.GetFileName(pic));
                progressBar1.Value++;
            }
        }
    }
