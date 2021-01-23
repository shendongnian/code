    /// <summary>
    /// Copy A to B where B doesn't have A nodes.
    /// </summary>
    public static void EvenUp(XElement A, XElement B)
    {
        XNode lastB = null, nodeA = null, nodeB = null;
    
        Action Copy_A_To_B = () =>
        {
            if (null == lastB)
                B.AddFirst(nodeA);
            else
                lastB.AddAfterSelf(nodeA);
        };
    
        var listA = A.Nodes().ToList();
        var listB = B.Nodes().ToList();
        int a, b;
    
        for (a = 0, b = 0; a < listA.Count && b < listB.Count; a++, b++)
        {
            nodeA = listA[a];
            nodeB = listB[b];
    
            XElement xA = nodeA as XElement,
                xB = nodeB as XElement;
    
            XText tA = nodeA as XText,
                tB = nodeB as XText;
    
            if (null != xA && null != xB)
            {
                if (xA.Name.LocalName == xB.Name.LocalName)
                    EvenUp(xA, xB);
                else
                {
                    Copy_A_To_B();
                    EvenUp(A, B); // Restart this iteration for various reasons such as 
                                    // the next nodeA might be the same as current nodeB
                    return;
                }
            }
            else if (null != xA)
                Copy_A_To_B();
            else if (null != tA && null != tB)
            {
                if (tA.Value != tB.Value)
                    tB.Value = tA.Value;
            }
            else if (null != tA)
                Copy_A_To_B();
    
            lastB = nodeB;
        }
        for (; a < listA.Count; a++)
        {
            nodeA = listA[a];
            Copy_A_To_B();
            if (null == lastB)
                lastB = B.FirstNode;
            else
                lastB = lastB.NextNode;
        }
    }
