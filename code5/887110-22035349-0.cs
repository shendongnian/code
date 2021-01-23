    public void PopulateTree(ref TreeNode root,List<Department> departments)
    {
        if(root==null)
        {
              root=new TreeNode();
              root.Text="Departments";
              root.Tag=null;
              // get all departments in the list with parent is null
              var details=departments.Where(t=>t.Parent==null);
              foreach(var detail in details)
              {
                  var child= new TreeNode(){
                      Text=detail.Name,
                      Tage=detail.Id,
                  };
                  PopulateTree(ref child,departments);
                  root.Nodes.Add(child);
              }      
        }
        else
        {
             var id=(int)root.Tag;
             var details=departments.Where(t=>t.Parent==id);
             foreach(var detail in details)
             {
                  var child= new TreeNode(){
                      Text=detail.Name,
                      Tage=detail.Id,
                  };
                  PopulateTree(ref child,departments);
                  root.Nodes.Add(child);
             }
        }
    }
