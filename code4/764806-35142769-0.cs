    protected void load_data()
        {
    
            string sql_text = "select * from category_master where parent_category_code = 0"; //only root categories
    
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql_text;
            cmd.Connection = connection;
            connection.Open();
    
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string cat_code = rdr["category_code"].ToString();
                string cat_name = rdr["category_name"].ToString();
    
                TreeNode parent = new TreeNode();
                parent.Value = cat_code;
                parent.Text = cat_name;
                tw.Nodes.Add(parent);
    
                add_childs(parent, cat_code);
        
            }
    
            connection.Close();
       
        }
    
    
     protected void add_childs(TreeNode tn, string category_code)
        { 
    
            string sql_text = "select * from category_master where parent_category_code = @category_code"; 
    
            SqlConnection connection = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql_text;
            cmd.Parameters.AddWithValue("@category_code", category_code);
            cmd.Connection = connection;
            connection.Open();
    
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string  cat_code = rdr["category_code"].ToString();
                string cat_name = rdr["category_name"].ToString();
    
                TreeNode child = new TreeNode();
                child.Value = cat_code;
                child.Text = cat_name;
                tn.ChildNodes.Add(child);
    
                add_childs(child, cat_code); //calling the same function
            }
    
            connection.Close();
        
        }
