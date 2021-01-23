    public TreeNode BuildTree(IEnumerable<Input> inputs)
    {
        TreeNode rootNode = null;
        // Build a dictionary to store each input and its node
        var dict = inputs.ToDictionary(
            input => input.Id,
            input => new { Input = input, Node = new TreeNode(input.Id.ToString()) });
        // Iterate through the nodes and build relationship among them
        foreach(var value in dict.Values)
        {
            var input = value.Input;
            if(input.ParentId != null)
            {
                dict[(int)input.ParentId].Node.Nodes.Add(value.Node);
            }
            else
            {
                rootNode = value.Node;
            }
        }
        return rootNode;
    }
