    Image img = new Image();
     img = UserControl1.FindControl("Image1") as Image;
     if (img != null)
     {
        Response.Write(img.ImageUrl);
      }
      else
      {
          Response.Write("Null");
       }
  
