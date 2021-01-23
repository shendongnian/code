    private void button1_Click(object sender, EventArgs e)
    {
    	DataTable dt = GlobalClasses.Data.AuthenticateUsers();
    	try
    	{
    		for(var i=0; i < dt.Rows.Count ; i++){
    			var dr = dt.Rows[i]; 
    			if (dr["UserName"].ToString() == UsernameTxtBox.Text 
    			&& dr["Password"].ToString() == PasswordTxtBox.Text ){
    				if (dr["Admin"].ToString() == "true"){
    					MessageBox.Show("Hello Admin");
    				} 
    				else 
    				{
    					MessageBox.Show("Hello Normal User");
    				}
    			} 
    			else 
    			{
    				MessageBox.Show("Get Away");
    			}
    		}             
    	}
    }
