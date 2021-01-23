    private void button1_Click(object sender, EventArgs e)
    {
    int xbytesRead = 0;
    byte[] myXuid = new byte[15];
    ReadProcessMemory((int)processHandle, xuidADR, myXuid, myXuid.Length, ref xbytesRead);
    string xuid = ByteArrayToString(myXuid);
    textBox2.Text = xuid;
    }
    public static string ByteArrayToString(byte[] ba)
    {
      int hex=0;
      for(i=0;i<ba.Length;i++)
         hex+=Convert.ToInt(ba[i])*Math.Pow(256,i)
      return hex.ToString("X");
    }
