    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (TreeView1.CheckedNodes.Count > 0)
        {
            foreach (TreeNode node in TreeView1.CheckedNodes)
            {
                //The main parent node does not have a parent
                if(node.Parent != null)
                {
                    string checkedValue = node.Text.ToString();
                    activityData = new ActivityData { ActivityName = checkedValue };
                    listActivity.Add(activityData);
                }
            }
            //stablish the session variable only when the foreach has finished
            Session["listActivity"] = listActivity;
         }
    }
