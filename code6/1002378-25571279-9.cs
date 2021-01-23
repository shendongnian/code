    Queue<byte[]> queue = new Queue<byte[]>();
    byte[] block;
    queue.Enqueue(new byte[] { 10, 11, 12, 13 });
    queue.Enqueue(new byte[] { 20, 21, 22, 23 });
    queue.Enqueue(new byte[] { 30, 31, 32, 33 });
    block = queue.Dequeue();
    queue.Enqueue(new byte[] { 40, 41, 42, 43 });
    block = queue.Dequeue();
    block = queue.Dequeue();
    queue.Enqueue(new byte[] { 50, 51, 52, 53 });
    queue.Enqueue(new byte[] { 60, 61, 62, 63 });
    queue.Enqueue(new byte[] { 70, 71, 72, 73 });
    block = queue.Dequeue();
    // ...
