    System.IO.MemoryStream ms = new System.IO.MemoryStream();
  
    image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
      Response.ClearContent();
      Response.ContentType = "image/Gif";
      Response.BinaryWrite(ms.ToArray());
    
    
    <asp:Image ID="Image1" runat="server" ImageUrl="~/pic.aspx"/>
