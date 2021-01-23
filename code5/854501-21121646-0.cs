    <%@ Page Language="C#"  Debug="true" %>
    <%@ Import namespace="System.Net" %>
    <script runat="server">
    public class Whatever
    {
    public static string output()
    {
    string hostname = "localhost";
    int portno = 52791;
    //IPAddress ipa = Dns.GetHostEntry(hostname).AddressList[0];
    byte[] ipb = {192,168,1,30};
    IPAddress ipa = new IPAddress(ipb);
    string ret = "";
    try
    {
        System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
        sock.Connect(ipa, portno);
        if (sock.Connected == true)  // Port is in use and connection is successful
                ret = "Port is Closed";
        sock.Close();
    
    }
    catch (System.Net.Sockets.SocketException ex)
    {
        if (ex.ErrorCode == 10061)  // Port is unused and could not establish connection 
            ret = "Port is Open!";
        else
            ret = ex.Message;
    }
    return ret;
    }
    }
    </script>
