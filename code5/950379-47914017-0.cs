    using System.Net;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    using System.Text;
    
    .......
    byte[] Combine(byte[] a1, byte[] a2, byte[] a3)
    {
        byte[] ret = new byte[a1.Length + a2.Length + a3.Length];
        Array.Copy(a1, 0, ret, 0, a1.Length);
        Array.Copy(a2, 0, ret, a1.Length, a2.Length);
        Array.Copy(a3, 0, ret, a1.Length + a2.Length, a3.Length);
        return ret;
    }
    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        string host = "192.168.1.43";
        int port = 6301;
        TcpClient tcpclnt = new TcpClient();
        string str = "MSH|^~\\&||.|||199908180016||ADT^A04|ADT.1.1698593|P|2.5\r\nPID|1||000395122||PEREZ^ADRIAN^C^^^||19880517180606|M|";
        try
        { 
            tcpclnt.Connect(host, port);
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] b1 =  {0x0B};
            byte[] b2 = {0x1C, 0x0D}; 
            // add header an tail to message string
            byte[] ba = Combine(b1, asen.GetBytes(str), b2);
            Stream stm = tcpclnt.GetStream();
            stm.Write(ba, 0, ba.Length);
            byte[] bb = new byte[600];
            int k = stm.Read(bb, 0, 600);
            string s = System.Text.Encoding.UTF8.GetString(bb, 0, k-1);
            Label1.Text = s;
            tcpclnt.Close();
        }
        catch (Exception ex) 
        {
            Label1.Text = ex.Message;
        }
    }
