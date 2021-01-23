    private Main _mainForm;
    public AddWeapon()
    {
        InitializeComponent();
    }
    public AddWeapon(Main mainForm) : this()
    {
     this._mainForm = mainForm;
    }
    // remaining code.
    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\brmcbrid\Documents\Visual Studio 2010\Projects\WindowsFormsApplication2\WindowsFormsApplication2\UserLogin.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlCommand cmd = new SqlCommand("INSERT into WeaponData values('" + serialNumber.Text + "','" + brand.Text + "','" + model.Text + "','" + caliber.Text + "','" + type.Text + "' , '" + dateAcquired.Text + "', '" + dateSold.Text + "', '" + purchasePrice.Text + "', '" + sellPrice.Text + "', '" + notes.Text + "')", con);
        // call a public method on the main form that can update the data.
        this._mainForm.UpdateData();
      
        this.Close();
    }
}
