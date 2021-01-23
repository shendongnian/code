    private static List<T> Merge<T>(Queue<T> Left, Queue<T> Right)
    {
        List<T> Result = new List<T>();
        while (Left.Count > 0 && Right.Count > 0)
        {
            int cmp = Comparison((Left.Peek() as Entity), (Right.Peek() as Entity));
            //If cmp is less than 0, left is less. If it is greater, left is greater
            if (cmp < 0)
                Result.Add(Left.Dequeue());
            else
                Result.Add(Right.Dequeue());
        }
        // ...
