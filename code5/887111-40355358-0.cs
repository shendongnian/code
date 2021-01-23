        private void grupAltGrup_Load(object sender, EventArgs e)
        {   DataTable dtt = veritabani.tablogonder("select id, ad from grup where parent=-1");
            TreeNode parent = new TreeNode();
            parent.Text = "Kök";
            parent.Tag = "-1";
            parent.ImageIndex = 0;
            treeView1.Nodes.Add(parent);
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                //       treeView1.Nodes.Add("Suppliers");
                TreeNode parent2 = new TreeNode();
                parent2.Text = dtt.Rows[i]["ad"].ToString();
                parent2.Tag = dtt.Rows[i]["id"].ToString(); 
                parent2.ImageIndex = 0;
                 
                parent.Nodes.Add(parent2);
                treeviewDoldur(ref parent2,Convert.ToInt16(dtt.Rows[i]["id"]));
                //   child.Nodes.Add("Name: " + dtt.Rows[i]["id"].ToString());
            }
     int kacinciyavru = 1;
        void treeviewDoldur(ref TreeNode parent,int parentIdsi)
        {            DataTable yedek;
            yedek = veritabani.tablogonder("select id,ad from grup where parent=" + parentIdsi);
            for (int y = 0; y < yedek.Rows.Count; y++)
            {
                TreeNode child = new TreeNode();
                child.Text = yedek.Rows[y]["ad"].ToString();
                child.Tag = yedek.Rows[y]["id"].ToString();
                child.ImageIndex = kacinciyavru++;
               parent.Nodes.Add(child); 
                treeviewDoldur(ref child, Convert.ToInt16(yedek.Rows[y]["id"])); 
            }
            kacinciyavru--;
        }
