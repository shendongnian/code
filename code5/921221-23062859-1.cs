      // dt1 is something with all rows with columns Id, ParentId, Operator together
      DataTable dt1 = null;
      var map = new Dictionary<int, Node>();
      var rootNodes = new List<Node>();
      foreach(DataRow row in dt1.Rows) {
        int id = Convert.ToInt32(row["Id"]);
        int? parentId = null;
        if (!row.IsNull("ParentId")) {
          parentId = Convert.ToInt32(row["ParentId"]);
        }
        string op = Convert.ToString(row["Operator"]);
        map[id] = new Node {
          Id = id,
          ParentId = parentId,
          Operator = op
        };
      }
      foreach (var pair in map) {
        if (pair.Value.ParentId.HasValue) {
          var parent = map[pair.Value.ParentId.Value];
          pair.Value.Parent = parent;
          parent.Children.Add(pair.Value);
        } else {
          rootNodes.Add(pair.Value);
        }
      }
 
