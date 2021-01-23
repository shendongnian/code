    for (int i = 0; i < MyList.Count; i++)
    {
         MyTree.Nodes.Add(MyList[i].GetP() + " " + MyList[i].GetSt());
         MyTree.Nodes[i].Nodes.Add(MyList[i].GetSe());
         MyTree.Nodes[i].Nodes[i].Nodes.Add(MyList[i].GetI());
    }
