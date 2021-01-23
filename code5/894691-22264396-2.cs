    public partial class MainForm : Form
    {
        public Connect Server
        { get; set; }
        private void connectServer()
        {
            Server.connect("123.456.789");
        }
    }
