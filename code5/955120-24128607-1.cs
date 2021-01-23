    public void Remove (PictureBox pb)
         if (pb.Tag.ToString().Lenght > 1) {
             // Greater than 1 because we need to keep one D in case of DD, 
             String temp = pb.tag.ToString();
             pb.tag = temp.Substring(0, temp.Lenght-2);
         }
         else 
            pb.Tag = "D";
            // Tag equals D because if there is only one D, it won't be deleted  
    }
   
