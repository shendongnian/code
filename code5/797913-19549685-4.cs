    var currentNode = list.First;
    while (currentNode.Next != null)
    {
        if (currentNode.Value.color == "blue")
        {
            var toRemove = currentNode;
            currentNode = currentNode.Next;
            list.Remove(toRemove);
        }
        else
        {
            currentNode = currentNode.Next;
        }
    }
