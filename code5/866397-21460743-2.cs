    List<Message> ml = new List<Message>();
    foreach (Message mx in q.GetMessageEnumerator2())
    {
        ml.Add(mx);
    }
    Message[] m = ml.ToArray();
