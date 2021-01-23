    public partial class MainWindow : Window
    {
        static void xmppCon_OnLogin(object sender) 
        {
            System.Windows.MessageBox.Show("Logged in to server");
            AnimateUtils.animategrid("loginscreen", "away", "backgroundimg");  
        }
    }
