    public partial class MainWindow : Window
    {
 
       TCPConnection myCon = new TCPConnection();
 
       private void connectButton_Click(object sender, RoutedEventArgs e)
       {
           networkListBox.Items.Add("Connecting...");
           myCon.Connect("localhost", updateNetworkListBox);
       }
    
    
        public delegate void updateNetworkListBoxDelegate(string message);
        public void updateNetworkListBox(string message)
        {
            if(this.invokeRequired())
            {
                this.invoke(new updateNetworkListBoxDelegate(updateNetworkListBox), message);
            }
            else
            {
                networkListBox.Items.Add(message);
            }
        }
    }
