        var tasks = new Queue<KeyValuePair<int[],Task>>();
        foreach (var temp in Generator()) {
            var arr = temp;
            tasks.Enqueue(new KeyValuePair<int[], Task>(arr, Task.Run(() ={
                //... use arr as needed
            }));
            if (tasks.Count > 7) {
                Task.WaitAny(
                    t.Select(v => v.Value).Where(t=>!t.IsCompleted).ToArray()
                );
                var first = tasks.Peek();
                while (first.Value.IsCompleted) {
                    Storage.UpdateStart(first.Key);
                    tasks.Dequeue();
                    first = tasks.Peek();
                }
            }
        }
