    public string SendWihSsl(string dataToSend)
    {
        Byte[] data = System.Text.Encoding.UTF8.GetBytes(dataToSend);
 
        ssl.Write(data, 0, data.Length);
        ssl.Flush();
        data = new Byte[2048];
 
        int myBytesRead = 0;
        StringBuilder myResponseAsSB = new StringBuilder();
        do
        {
            myBytesRead = ssl.Read(data, 0, data.Length);
            myResponseAsSB.Append(System.Text.Encoding.UTF8.GetString(data, 0, myBytesRead));
            if (myResponseAsSB.ToString().IndexOf("</") != -1)
            {
                break;
            }
        } while (myBytesRead != 0);
 
        return myResponseAsSB.ToString();
    }
