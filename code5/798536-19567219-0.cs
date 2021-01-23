    private void Loop(PreviewObject po)
    {
        Queue<PreviewObject> queue = new Queue<PreviewObject>();
        queue.Enqueue(po);
        while(queue.Count != 0)
        {
            PreviewObject next = queue.Dequeue();
            foreach(PreviewObject obj in next.Childrens)
                queue.Enqueue(obj);
            // Replace with the actual processing you need to do on the item
            Console.WriteLine(next.Name);
        }
    }
