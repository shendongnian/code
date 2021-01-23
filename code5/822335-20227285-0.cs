    public IEnumerator GetEnumerator()
    {
        ListNode node = firstNode;
        while (node != null)
        {
            yield return node;
            node = node.Next;
        }
    }
