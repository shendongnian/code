        var tasks = new Queue<Pair<int[],Task>>();
        foreach (var temp in Generator()) {
            var arr = temp;
            tasks.Enqueue(new Pair<int[], Task>(arr, Task.Run(() ={
                //... use arr as needed
            }));
            var tArray = t.Select(v => v.Value).Where(t=>!t.IsCompleted).ToArray();
            if (tArray.Length > 7) {
                Task.WaitAny(tArray);
                var first = tasks.Peek();
                while (first != null && first.B.IsCompleted) {
                    Storage.UpdateStart(first.A);
                    tasks.Dequeue();
                    first = tasks.Count == 0 ? null : tasks.Peek();
                }
            }
        }
    ...
    class Pair<TA,TB> {
        public TA A { get; set; }
        public TB B { get; set; }
        public Pair(TA a, TB b) { A = a; B = b; }
    }
