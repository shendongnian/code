    private TreeNode DirectoryToTreeView(TreeNode parentNode, string path,
                                         string extension = ".txt") {
      var result = new TreeNode(parentNode == null ? path : Path.GetFileName(path));
      foreach (var dir in Directory.GetDirectories(path)) {
        TreeNode node = DirectoryToTreeView(result, dir);
        if (node.Nodes.Count > 0) {
          result.Nodes.Add(node);
        }
      }
      foreach (var file in Directory.GetFiles(path)) {
        if (Path.GetExtension(file).ToLower() == extension.ToLower()) {
          result.Nodes.Add(Path.GetFileName(file));
        }
      }
      return result;
    }
