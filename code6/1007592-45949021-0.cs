    public class Yourclass {  
    
           var nodeStates = new Dictionary<int, bool>();
        
             public void addNode(Yourentity entity) 
             {
                  TreeNode node= new TreeNode(entity.Name);
                  node.Tag = entity;
                  tree.Nodes.Add(entity);
                  nodeStates.Add(entity.Id, true /* expanded in this case but doesn't matter */);
             }
              
           private void TreeControl_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
             var entity = (Yourentity )e.Node.Tag;
             bool state = nodeStates[entity.Id];
             
             // If was expanded or collapsed values will be different
             if (e.Node.IsExpanded != state)
             {
                // We update the state
                 nodeStates[entity.Id] = e.Node.IsExpanded;
                 return;
             }
             /* Put here your actual node click code */
         }
    }
