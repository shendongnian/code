    private HomeScreen fHome = new HomeScreen();
    private CustomerScreen fCustomer = new CustomerScreen();
    private void MainTab_Load(object sender, EventArgs e)
    {
        fHome.TopLevel = false;
        fHome.Visible = true;
        fHome.FormBorderStyle = FormBorderStyle.None;
        fHome.Dock = DockStyle.Fill;
        MainOptions.TabPages[0].Controls.Add(fHome);
        fHome.Show(); // add this
    }
    private void CustomerTab_Click(object sender, EventArgs e)
    {
        fCustomer.TopLevel = false;
        fCustomer.Visible = true;
        fCustomer.FormBorderStyle = FormBorderStyle.None;
        fCustomer.Dock = DockStyle.Fill;
        MainOptions.TabPages[1].Controls.Add(fCustomer);
        fCustomer.Show(); // add this
    }
