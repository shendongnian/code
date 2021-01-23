     List<System.Object> list = Json.Deserialize(response) as List<System.Object>;
     Dictionary<string, object> row;
     foreach (System.Object obj in list)
     {
         row = obj as Dictionary<string, object>;
         // Do whatever with row
     }     
  
