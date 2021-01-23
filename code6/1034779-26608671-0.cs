    public partial class MainWindow : Window {
    private string[] ips;
    
    public MainWindow()
    {
        InitializeComponent();
        try
        {
            IPAddress[] addrs = Array.FindAll(Dns.GetHostEntry(string.Empty).AddressList,
               a => a.AddressFamily == AddressFamily.InterNetwork);
            ServerOutputTextBox.AppendText("Your IPv4 address is: ");
            foreach (IPAddress addr in addrs)
            {
                ServerOutputTextBox.AppendText(addr.ToString());
            }
            //Automatically set the IP address
            ips = addrs.Select(ip => ip.ToString()).ToArray();
            
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    private void StartServerButton_Click(object sender, RoutedEventArgs e)
    {
         Response.StartListening(ips);
    }
