    private void btnSupplier_Click(object sender, EventArgs e)
    {
        Panel pnlAddSupplier = new Panel()
        {
            Name = "pnlAddSupplier",
            Location = new Point(56, 74),
            Size = new Size(200, 200),
            BorderStyle = BorderStyle.Fixed3D
        };
        TextBox txtSupplierID = new TextBox()
        {
            Name = "txtSupplierID",
            Location = new Point(20, 40),
            Text = string.Empty,
            Size = new Size(152, 20)
        };
        TextBox txtSupplierName = new TextBox()
        {
            Name = "txtSupplierName",
            Location = new Point(20, 90),
            Text = string.Empty,
            Size = new Size(152, 20)
        };
        Label lblSupplierID = new Label()
        {
            Name = "lblSupplierID",
            Location = new Point(20, 20),
            Text = "Supplier ID:",
            Size = new Size(104, 20)
        };
        Label lblSupplierName = new Label()
        {
            Name = "lblSupplierName",
            Location = new Point(20, 70),
            Text = "Supplier Name:",
            Size = new Size(150, 20)
        };
        Button btnAddSupplier = new Button()
        {
            Name = "btnAddSupplier",
            Location = new Point(60, 120),
            Text = "Add",
        };
        btnAddSupplier.Click += btnAdd_Click;
        // Add controls to the Panel.
        pnlAddSupplier.Controls.Add(lblSupplierID);
        pnlAddSupplier.Controls.Add(txtSupplierID);
        pnlAddSupplier.Controls.Add(lblSupplierName);
        pnlAddSupplier.Controls.Add(txtSupplierName);
        pnlAddSupplier.Controls.Add(btnAddSupplier);
        // Add the Panel control to the form. 
        this.Controls.Add(pnlAddSupplier);
    }
    public void btnAdd_Click(object sender, EventArgs e)
    {
        string username = this.Controls["pnlAddSupplier"].Controls["txtSupplierName"].Text;
        int age = Int32.Parse(this.Controls["pnlAddSupplier"].Controls["txtSupplierID"].Text);
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
        string query = "INSERT INTO table(username, age) VALUES ('@xxx', '@xxx') ";
        using (connection)
        {
            ObjDb.OpenConnection();
            ObjDb.ExecuteNonQuery(query, connection);
        }
    }
