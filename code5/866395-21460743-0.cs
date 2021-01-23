    List<Message> ml = new List<Message>();
    MessageEnumerator me = q.GetMessageEnumerator2();
    for (int i = 0; i < 10; i++)
    {
        me.MoveNext();
        ml.Add(me.Current);
    }
    Message[] m = ml.ToArray();
