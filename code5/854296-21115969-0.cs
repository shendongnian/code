    public Node Next { get; set; }
    public Node()
    {
        Node next;
        if (dic.TryGetValue(key, out next))
            this.Next = next;
        dic[key] = this;
    }
