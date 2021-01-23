    public static Tree<dynamic> MakeDynamic<T>(this Tree<T> inputTree)
    {
        var newTree = new Tree<dynamic>();
        for (int i = 0; i < inputTree.Branches.Count; i++)
        {
            var newBranch=new Branch<dynamic>();
            newTree.Branches.Add(newBranch);
            for (int j = 0; j < inputTree.Branches[i].Leaves.Count; j++)
            {
                dynamic d = inputTree.Branches[i].Leaves[j];
                inputTree.Branches[i].Leaves[j] = d;
            }
        }
        return newTree;
    }
