    private static List<T> Merge<T>(Queue<T> Left, Queue<T> Right)
    {
        List<T> Result = new List<T>();
        while (Left.Count /* O(1) operation */ > 0 && Right.Count > 0)
        {
            int cmp = Comparison((Left.Peek() as Entity), (Right.Peek() as Entity));
            //If cmp is less than 0, left is less. If it is greater, left is greater
            if (cmp < 0)
                Result.Add(Left.Dequeue());
            //Left.RemoveAt(0) - Using a list to remove at a certain point is inefficient
            else
                Result.Add(Right.Dequeue());
        }
        // ...
