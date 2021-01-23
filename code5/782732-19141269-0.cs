        public static void AddRange<T>(this Queue<T> queue, IEnumerable<T> enu) {
            foreach (T obj in enu)
                queue.Enqueue(obj);
        }
        Queue<int> q = new Queue<int>();
        q.AddRange(otherList); //Work!
