    string myBytes = String.Empty;
    string dp = "î";                 
    //byte[] bdp = Encoding.ASCII.GetBytes(dp);
    byte[] bdp = Encoding.GetEncoding(437).GetBytes(dp);  //  <----- NOTE 437
    foreach (byte b in bdp)
    {
        myBytes += b.ToString("x") + " ";
    }
