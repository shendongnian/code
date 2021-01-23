    cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    private void fillCombo()
    {
    	string sql = "SELECT ID, NAME, Number, Email FROM tblPerson";
    	SqlConnection Cnn = new SqlConnection("connections string");
    	Cnn.Open();
    	
    	SqlDataAdapter da = new SqlDataAdapter(sql, Cnn);
    	DataTable dt = new DataTable();
    	da.Fill(dt);
    	
    	cmb.ValueMember = "ID";
    	cmb.DisplayMember = "Name";
    	cmb.DataSource = dt;	
    }
    
    private void cmb_SelectedValueChanged(object sender, EventArgs e)
    {
    	if (cmb.SelectedItem != null)
    	{
    		txtNumber.Text = ((DataRow)cmb.SelectedItem)["Number"].ToString();
    		txtEmail.Text = ((DataRow)cmb.SelectedItem)["Email"].ToString();
    	}
    }
    
    private void cmb_Validating(object sender, CancelEventArgs e)
    {
    	if (cmb.SelectedItem == null)
    	{
    		If (MessageBox.Show("Do you want to create a new person?", MessageBoxButtons.YesNo) == DialogResult.Yes)
    		{
    			frmNewPerson person = new frmNewPerson();
    			person.Name = cmb.Text;
    			if (person.ShowDialog() == DialogResult.Yes)
    			{
    				fillCombo();
    				DataRow dr = ((DataTable)cmb.DataSource).Select("Name='" + person.Name + "'")[0];
    				cmb.SelectedValue = Convert.ToInt32(dr["ID"]);
    			}
    		}
    		else
    		{
    			txtNumber.Text = string.Emtpy;
    			txtEmail.Text = string.Emtpy;
    		}
    	}
    }
