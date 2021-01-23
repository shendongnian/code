    String strConn = "Server = .\\SQLEXPRESS;Database = Northwind;Integrated Security = SSPI;";
    SqlConnection conn = new SqlConnection(strConn);
    SqlDataAdapter da = new SqlDataAdapter("Select * from Products", conn);
    SqlDataAdapter daCategories = new SqlDataAdapter("Select * from Categories", conn);
    da.Fill(ds, "Products");
    daCategories.Fill(ds, "Categories");
    ds.Relations.Add("Cat_Product", ds.Tables["Categories"].Columns["CategoryID"], ds.Tables["Products"].Columns["CategoryID"]);
    foreach(DataRow dr in ds.Tables["Categories"].Rows)
    {
           TreeNode tn = new TreeNode(dr["CategoryName"].ToString());
           foreach (DataRow drChild in dr.GetChildRows("Cat_Product"))
           {
                  tn.Nodes.Add(drChild["ProductName"].ToString());
           }
           treeView1.Nodes.Add(tn);
    }
