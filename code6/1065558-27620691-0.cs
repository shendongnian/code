    protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.ContentType = "text/xml";
            System.IO.StreamReader reader = new System.IO.StreamReader ( Page.Request.InputStream );
            String xmlData = reader.ReadToEnd ();
            System.IO.StreamWriter SW;
            SW = File.CreateText ( Server.MapPath(".")+@"\"+ Guid.NewGuid () + ".xml" );
            SW.WriteLine ( xmlData );
            SW.Close ();
        }
