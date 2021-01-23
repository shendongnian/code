    protected void Page_Load(object sender, EventArgs e)
        {
            string text = "Hello";
            //1. Return the "text" variable to the client that requested this page
    
                  Response.ContentType = "text/plain";
                 
                  Response.BufferOutput = false;
                  Response.BinaryWrite(GetBytes(text));
    
                  Response.Flush();
                  Response.Close();
                  Response.End();
        }
    
    static byte[] GetBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
