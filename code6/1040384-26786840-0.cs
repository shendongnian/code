    if (File.Exists(FullPath))
        {
            using(Image i = Image.FromFile(FullPath))
            {
                DrawImage(i, pnlPicture, pbColor.BackColor); //I disabled this so the problem is not here
                //GC.Collect(); //I know I know... I should never call GC. So disabled it :) 
            }
        }
        else
        {
            //DrawImage(Properties.Resources.Fail800, pnlPicture, Color.White, true);
        }
    }
