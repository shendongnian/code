    public Form1()
    {
        InitializeComponent();
        initTreeView();  //TreeView without any nodes in it
    }
    void initTreeView()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = _ConnectionString;
        con.Open();
        using (SqlCommand comm = new SqlCommand("Select Name From Employees", con))
        using (SqlDataReader read = comm.ExecuteReader())
            while (read.Read())
            {
                TreeNode tn = new TreeNode(read["Name"].ToString());
                tn.Nodes.Add(new TreeNode());
                treeView1.Nodes.Add(tn);
            }
        
        treeView1.BeforeExpand += treeView1_BeforeExpand;
    }
    void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        TreeNode tNode = e.Node;
        string empName = tNode.Text;
        tNode.Nodes.Clear();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = _ConnectionString;
        con.Open();
        using (SqlCommand comm = new SqlCommand("Select Age, PhoneNumber From Employees Where Name = @empName", con))
        {
            comm.Parameters.AddWithValue("@empName", empName);
            using (SqlDataReader read = comm.ExecuteReader())
                if (read.Read())
                {
                    TreeNode nodeAge = new TreeNode(read["Age"].ToString());
                    TreeNode nodePhone = new TreeNode(read["PhoneNumber"].ToString());
                    tNode.Nodes.AddRange(new TreeNode[] { nodeAge, nodePhone });
                }
        }
    }
