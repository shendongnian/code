    for (int i = 0; i < treevwaccess.Nodes.Count; i++)
    { 
          formid = treevwaccess.Nodes[i].Name;
          access = treevwaccess.Nodes[i].Checked;
          user.updateaccesslevel(lblId.Text, formid, access);
          CheckChildNodes(treevwaccess.Nodes[i]);
    }
    
    void CheckChildNodes(TreeNode node)
    {
          if (node.Nodes.Count > 0)
          {
              for (int i = 0; i < node.Nodes.Count; i++)
              {
                  formid = node.Nodes[i].Name;
                  access = node.Nodes[i].Checked;
                  user.updateaccesslevel(lblId.Text, formid, access);
              }
           }
    }
