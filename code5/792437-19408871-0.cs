      Control FindControlRecursive(Control root, string name) {
          if (root.Name == name) {
             return base;
          }
          for (int i = 0; i < root.Controls.Count; ++i) {
               Control current = root.Controls[i];
               if (current .Name == name) {
                   return current ;
               }
               else {
                   Control recursiveControls = FindControlRecursive(current , name);
                   if (recursiveControl != null)
                   {
                        return recursiveControls;
                   }
               }
          }
          return null;
      }
   
