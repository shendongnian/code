    public static class MyNodeExt<T>
    {
       IEnumerable<T> TraverseLeafs<T>(this MyNode<T> node)
       {
           if (node.Children.Count == 0)
               yield return node;
           else
           {
               foreach(var child in root.Children)
               {
                   foreach(var subchild in child.TraverseLeafs())
                   {
                       yield return subchild;
                   }
               } 
           }
       }
    }
