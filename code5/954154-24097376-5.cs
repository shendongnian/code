    List<int> exampleList = new List<int> { 1, 3, 5, 6, 7, 8, 6, 5, 6, 6 };
    List<int> customSelection = new List<int> { 1, 5, 6, 6, 8 };
    
    var diffLinkedList = new LinkedList<int>(exampleList);
    var customSelectionDic = customSelection.GroupBy(n => n)
                                            .ToDictionary(g => g.Key, g => g.Count());
    var currentNode = diffLinkedList.First;
    while (currentNode != null)
    {
        int value = currentNode.Value;
        int count = 0;
        if (customSelectionDic.TryGetValue(value, out count))
        {
            var nextNode = currentNode.Next;
            diffLinkedList.Remove(currentNode);
            if (count == 1)
            {
                customSelectionDic.Remove(value);
                if (customSelectionDic.Count == 0)
                    break;
            }
            else
                customSelectionDic[value] = count - 1;
            currentNode = nextNode;
        }
        else
            currentNode = currentNode.Next;
    }
    
    var diffList = diffLinkedList.ToList(); // 3, 7, 5, 6, 6
