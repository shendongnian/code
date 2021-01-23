    public static class fileUpload
    {
        TextBox textBox1 = new TextBox();
    
        public static void getText(TextBox tb) {
             return tb.text;
        }
    
        public static string uploadFile(string file)
        {
            var aText = getText(textBox1);
    
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.mywebserver.com/%2f"+ aText + ".txt");
            
            // ....
