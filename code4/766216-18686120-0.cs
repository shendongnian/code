    int count = q.Count;
    for (int i = 0 ; i != count ; i++) {
        var item = q.Dequeue();
        if (!toRemove.Equals(item)) {
            q.Enqueue(item);
        }
    }
