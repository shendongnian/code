    public partial class RemoteFileDialog : Form
    {
        public Server server = new Server( new ServerConnection("ServerName", "User", "Password") );
        /* ... */
        public void getServerDrives()
        {
            DataTable d = server.EnumAvailableMedia();
            foreach (DataRow r in d.Rows)
                treeView.Nodes.Add( new TreeNode(r["Name"].ToString() );
        }
        /* ... */
        //populate a node with files and subdirectories when it's expanded
        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            DataSet ds = server.ConnectionContext.ExecuteWithResults(string.Format("exec xp_dirtree '{0}', 1, 1", e.Node.FullPath));
            ds.Tables[0].DefaultView.Sort = "file ASC"; // list directories first, then files
            DataTable d = ds.Tables[0].DefaultView.ToTable();
            foreach (DataRow r in d.Rows)
                e.Node.Nodes.Add( new TreeNode(r["subdirectory"].ToString());
        }
    }
