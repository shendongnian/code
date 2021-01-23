     protected void Button1_Click(object sender, EventArgs e)
        {
            var start = Convert.ToDateTime(txtDate1.Text);
            var end = Convert.ToDateTime(txtDate2.Text);
    
            if (end < start)
                return;
    
            var folderNamelst = GetListOfExsistingFolderName(start, end);
            AddNodes(folderNamelst);
        }
    
        private IEnumerable<string> GetListOfExsistingFolderName(DateTime startDate, DateTime endTime)
        {
            var mainFolderPath = Server.MapPath("~/Folders");
            var folderNamelst = new List<string>();
            var day = startDate;
            do
            {
                if (Directory.Exists(mainFolderPath + "\\" + day.ToString("MM-dd-yyyy")))
                    folderNamelst.Add(day.ToString("MM-dd-yyyy"));
                day = day.AddDays(1);
            } while (day <= endTime);
    
            return folderNamelst;
        }
    
        private void AddNodes(IEnumerable<string> data)
        {
            TreeView1.Nodes.Clear();
    
            var root = new TreeNode("Folders");
    
            foreach (var d in data)
            {
                var treechild = new TreeNode(d);
                root.ChildNodes.Add(treechild);
            }
            TreeView1.Nodes.Add(root);
        }
