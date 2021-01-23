    public static IPStatus CheckConn(string host, ref PingReply pngReply)
    {
        Ping png = new Ping();
        try
        {
            pngReply = png.Send(host);
            return pngReply.Status;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception: " + ex.Message());
        }        
    }
