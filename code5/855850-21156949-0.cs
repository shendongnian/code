    using System;
    using System.IO;
    using System.Web.UI;
    
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    	// 1.
    	// Get path of byte file.
    	string path = Server.MapPath("~/Adobe2.png");
    
    	// 2.
    	// Get byte array of file.
    	byte[] byteArray = File.ReadAllBytes(path);
    
    	// 3A.
    	// Write byte array with BinaryWrite.
    	Response.BinaryWrite(byteArray);
    
    	// 3B.
    	// Write with OutputStream.Write [commented out]
    	// Response.OutputStream.Write(byteArray, 0, byteArray.Length);
    
    	// 4.
    	// Set content type.
    	Response.ContentType = "image/png";
        }
    }
