    private void buttonAdd_Click(object sender, EventArgs e)
    {
        ClientCard f = new ClientCard(this);
        f.ShowDialog();
    }
    public partial class ClientCard : Form
    {
        private MainWindow MainWnd;
    
        public ClientCard(MainWindow Wnd)
            {
                InitializeComponent();
                MainWnd = Wnd;
            }
    }
