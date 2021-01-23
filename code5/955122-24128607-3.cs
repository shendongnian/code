    public void Remove (PictureBox pb){
         if (pb.Tag.ToString().Length > 1) {
             // Greater than 1 because we need to keep one D in case of DD, 
             String temp = pb.Tag.ToString();
             pb.Tag = temp.Substring(0, temp.Length - 2);
         }
         else 
            pb.Tag = "D";
            // Tag equals D because if there is only one D, it won't be deleted  
    }
   
