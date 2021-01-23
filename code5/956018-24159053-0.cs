    private void ping_Complete(object sender, PingCompletedEventArgs k)
    {
        foreach (TreeNode node in treeView1.Nodes)
        {
            PingReply reply = k.Reply;
            if(reply.Address==node.Text)
            {
               if (reply.Status == IPStatus.Success)
               {
                node.Text = node.Text + " (OK)";
               }
    
               else
               {
                  node.Text = node.Text + " (FAILED)";
               }
            }
        }
    }
