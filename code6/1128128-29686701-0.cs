    public void Insert_Button_Click(object sender, EventArgs e)
	{
		MyClass.InsertNewClient(fullNametxt.Text, shortNametxt.Text);
		this.tblClientTableAdapter.Fill(this.DataSetClient.tblClient);
	}
