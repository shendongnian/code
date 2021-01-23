    protected void siteSearchButton_Click(object sender, EventArgs e)
    {
        //checks IP search textbox is empty
        if (ipQueryTextBox.Text != null)
        {
            searchErrorLabel.Visible = false;
            string addresses = ipQueryTextBox.Text;
            //checks for any blank spaces in the addresses variable
            if (addresses.Contains(" "))
            {
                addresses = addresses.Replace(" ", "");
            }
            //sceens for multiple search items by looking for a ','
            if (addresses.Contains(","))
            {
                string[] IParray = addresses.Split(',');
                string[] Parameters= IParray.Select((IP, index)=>"@ip"+ index.ToString()).ToArray();
                string commandformat ="SELECT * FROM LOCATION WHERE IP_ADDRESS IN ({0})";
                string parametertxt= string.Join(",",Parameters);
                string commandtxt= string.Format(commandformat,parametertxt);
                
                //creates an SQL connection "connection" opens the connection creates the sql command to be executed & binds and refreshes the gridview
                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Inventory;Integrated Security=True"))
                {
                    SqlDataReader reader = null;
                    connection.Open();
                    SqlCommand command = new SqlCommand(commandtxt, connection);                
                
                    for(int i =0; i<Parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue(Parameters[i],IParray[i]);                        
                    }
                    reader = command.ExecuteReader();
                    browseSiteGridView.DataSource = reader;
                    browseSiteGridView.DataBind();
                    reader.Close();
                    connection.Close();
                    
                }
            }
            else
            {
                //creates an SQL connection "connection" opens the connection creates the sql command to be executed & binds and refreshes the gridview
                string commandtxt="SELECT * FROM LOCATION WHERE IP_ADDRESS ='"+addresses+"'";
                using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Inventory;Integrated Security=True"))
                {
                    SqlDataReader reader = null;
                    connection.Open();
                    SqlCommand command = new SqlCommand(commandtxt, connection);
                    reader = command.ExecuteReader();
                    browseSiteGridView.DataSource = reader;
                    browseSiteGridView.DataBind();
                    reader.Close();
                    connection.Close();
                }
            }
        }   
