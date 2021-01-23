    queue = new Queue()
    reveal clicked cell
    enqueue(clicked cell)
    while (queue is not empty)
    {
        cell = dequeue()
        for each neighbor X of cell
        {
            if (X is revealed)
            {
                continue;
            }
            reveal X
            if X has no adjacent mine
            {
               enqueue X
            }
        }
    }
