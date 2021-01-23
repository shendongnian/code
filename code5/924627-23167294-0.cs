    string fileExt = System.IO.Path.GetExtension(Imgdocname);
    fileExt = fileExt.ToLower();
    if (fileExt == ".jpeg" || fileExt == ".jpg")
    {
       docimg.ImageUrl = @"C:\\Search\\" + strName + "\\" + strFolder + "\\" + Imgdocname;
       Response.Write("Success");
    }
    else
    {
       Response.Write("fail");
    }
    
    <asp:Image ID="docimg" runat="server" />
