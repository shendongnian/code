     public Dictionary<string, object> CreateNestedDictionary(string[] chainNodes, object value) {
       return DoCreate(chainNodes, value, 0);
     }
     private Dictionary<string, object> DoCreate(string[] chainNodes, object value, int index) {
       var res = new Dictionary<string, object>();
       if (index == chainNodes.Length - 1) {
         // Bottom out the recursion
         res.Add(chainNodes[index], value);
       } else {
          res.Add(chainNodes[index], DoCreate(chainNodes, value, index+1));
       }
       return res;
     }
