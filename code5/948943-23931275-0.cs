      public static class TreeNodeExtensions {
        public static int Level(this TreeNode value) {
          if (Object.ReferenceEquals(null, value))
            throw new ArgumentNullException("value"); // <- or return 0 
    
          int result = 0;
          
          for (TreeNode node = value; node != null; node = node.Parent)
            result += 1;
    
          return result;
        }
      }
    
      ... 
    
      TreeNode node1 = ...
      TreeNode node2 = ...
    
      if (node1.Level() != node2.Level()) {
        ...
      } 
