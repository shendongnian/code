    public partial class MainForm : Form
    {
        Connect server = new Connect();
        server.initialize(); // call your initialize method
        private void connectServer()
        {
            server.connect("123.456.789"); // call the connect method here
        }
    }
