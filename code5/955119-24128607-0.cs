    public void Remove (PictureBox pb)
         if (pb.Tag.ToString().Lenght > 1) {
             String temp = pb.tag.ToString();
             pb.tag = temp.Substring(0, temp.Lenght-2);
         }
         else 
            pb.Tag = "D";  
    }
   
