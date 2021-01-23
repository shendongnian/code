    // ProductSelection form1; (you don't need this)
    public QuantityPriceForm()
    {
      InitializeComponent();
    }
    public int quant {
      get { return (int)txtQuantity.Text; }
      set { txtQuantity.Text = value.ToString(); }
    }
    public int agreePrice {
      get { return (double)txtAgreePrice.Text; }
      set { txtAgreePrice.Text = value.ToString(); }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      DialogResult saveData = MessageBox.Show("Do you want to save the data?",
        "Save Data",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
      if (saveData == DialogResult.OK)
      {
        this.DialogResult = saveData;
        this.Close();
      }
    }
