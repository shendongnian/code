    private IntNode _lastNode;
    public void Add(IntNode node)
    {
        if (_head == null)
            _head = node;
        else
        {
            if (_lastNode == null)
                _lastNode = _head;
            _lastNode.setNext(node)
            _lastNode = node;
        }
        count++;
    }
