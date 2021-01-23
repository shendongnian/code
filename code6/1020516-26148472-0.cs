    private string DecodeText(string sFileName)
    {
        DmtxImageDecoder decoder = new DmtxImageDecoder();
        System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap(sFileName);
        List<string> oList = decoder.DecodeImage(oBitmap);
        StringBuilder sb = new StringBuilder();
        sb.Length = 0;
        foreach (string s in oList)
        {
            sb.Append(s);
        }
        return sb.ToString();
    }
