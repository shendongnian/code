    ...
    ...
    GenerateTreeNodes("P", "FD", GetChildNodesByPitch, ComparePairsDistance);
    ...
    ...
    private void GenerateTreeNodes(string rootFormat, string childFormat,
                ActionRef2<SortedSet<TreeNode>,int, string> getChildNodes,
                Func<GCFacePointPair, GCFacePointPair, int> comparePairs)
            {
                int index = 0;
                while (index < fpps.Count)
                {
                    TreeNode rootNode = new TreeNode(fpps[index].ToString(rootFormat));
                    SortedSet<TreeNode> childNodes =
                        new SortedSet<TreeNode>(
                            Comparer<TreeNode>.Create((TreeNode a, TreeNode b) =>
                            {
                                return comparePairs((GCFacePointPair)a.Tag, (GCFacePointPair)b.Tag);
                            }));
    
                    getChildNodes(ref childNodes, ref index, childFormat);
    
                    /*childNodes.Sort((TreeNode a, TreeNode b) =>
                    {
                        return comparePairs((GCFacePointPair)a.Tag, (GCFacePointPair)b.Tag);
                    });*/
    
                    TreeNode[] nodes = new TreeNode[childNodes.Count];
                    childNodes.CopyTo(nodes);
                    rootNode.Nodes.AddRange(nodes);
                    //rootNode.Nodes.AddRange(childNodes.ToArray());
    
                    FacePointTreeView.Invoke((Func<TreeNode, int>)(FacePointTreeView.Nodes.Add), rootNode);
                }
            }
    
            private void GetChildNodesByPitch(ref SortedSet<TreeNode> childNodes, ref int index, string format)
            {
                GCPitch curr = fpps[index].Point.ID;
                while (index < fpps.Count && fpps[index].Point.ID == curr)
                {
                    TreeNode node = new TreeNode(fpps[index].ToString(format));
                    node.Tag = fpps[index];
                    childNodes.Add(node);
                    index++;
                }
            }
            private int ComparePairsDistance(GCFacePointPair a, GCFacePointPair b)
            { return Math.Sign(a.Distance - b.Distance); }
