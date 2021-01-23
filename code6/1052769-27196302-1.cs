    void GetNode(Node parent)
        {
            if (parent.ChildNodes.Any())
            {
               ParentN.Add(parent.Name, parent.Path);
               foreach(child in parent)
               {
                    childN.Add(child.Name, child.Path);
                    GetNode(child);
               }
            }
            Console.WriteLine(parent.Name);
        }
