    foreach(var n in Nodes)
    {
         if(n.GetType().GetGenericTypeDefinition() == typeof(VariableNode<>))
         {
              if(n.GetType().GetProperty("Variable").GetValue(n, null) == myVar) 
              {
                   toRemove.Add(n);
              }
         }
    }
