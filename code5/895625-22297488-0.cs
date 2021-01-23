    // in handler
    public void ProcessRequest(HttpContext context)
    {
    	long EmployeeID = -1;
    	if (context.Request.QueryString["n"] != null)
    		EmployeeID = long.Parse(context.Request.QueryString["n"].ToString());
    	//else
    	//    throw new ArgumentException("No parameter specified");
    
    	if (context.Request.QueryString["actid"] == "2")
    	{
    		ShowThumbPic(context, EmployeeID);
    		return;
    	}
            //else ...
    }
    private void ShowThumbPic(HttpContext context, long EmployeeID)
    {
        context.Response.ContentType = "image/jpeg";
        Stream myStream = GetEmpImage(EmployeeID);
        byte[] myImgByteArray;
    
        using (BinaryReader br = new BinaryReader(myStream))
        {
            myImgByteArray = br.ReadBytes((int)myStream.Length);
        }
        MemoryStream ms = new MemoryStream(byteArrayIn);
        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
    
        if (img.Height > 50 || img.Width > 50)
        {
            System.Drawing.Size siz = GetScaledSize(img.Size, new System.Drawing.Size(50, 50));
            img = (System.Drawing.Image)ResizeImage(img, siz);
        }
    
        MemoryStream ms = new MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        byte[] myBuffer = ms.ToArray();
        int byteSeq = myBuffer.Length; //myStream.Read(myBuffer, 0, 4096);
        if (byteSeq > 0)
            context.Response.OutputStream.Write(myBuffer, 0, byteSeq);
    }
    private System.Drawing.Image GetEmployeeImage(long EmployeeID)
    {
        System.Drawing.Image img = null;
        try
        {
            using (DAL.dstEmployeeTableAdapters.tbl_Employee_InfoTableAdapter ta = new DAL.dstEmployeeTableAdapters.tbl_Employee_InfoTableAdapter())
            {
                object obj = ta.spr_Employee_Info_GetPicture(EmployeeID);
                if (obj != null)
                {
                    MemoryStream ms = new MemoryStream((byte[])obj);
                    img = System.Drawing.Image.FromStream(ms);
                }
            }
        }
        catch (Exception x)
        {
            throw new Exception(Msg.Error_InDownloadPicture + x.Message);
        }
        return img;
    }
    public static Size GetScaledSize(Size ImageSize, Size FrameSize)
    {
        int newWidth = ImageSize.Width;
        int newHeight = ImageSize.Height;
        double ratioX = (double)FrameSize.Width / ImageSize.Width;
        double ratioY = (double)FrameSize.Height / ImageSize.Height;
        double ratio = Math.Min(ratioX, ratioY);
        if (ratio < 1.0f) // if Frame is greater than image, resize it.
        {
            newWidth = (int)(ImageSize.Width * ratio);
            newHeight = (int)(ImageSize.Height * ratio);
        }
        return new Size(newWidth, newHeight);
    }
    public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, Size siz)
    {
        //a holder for the result
        Bitmap result = new Bitmap(siz.Width, siz.Height);
        // set the resolutions the same to avoid cropping due to resolution differences
        result.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    
        //use a graphics object to draw the resized image into the bitmap
        using (Graphics graphics = Graphics.FromImage(result))
        {
            //set the resize quality modes to high quality
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //draw the image into the target bitmap
            graphics.DrawImage(image, 0, 0, result.Width, result.Height);
        }
    
        //return the resulting bitmap
        return result;
    }
