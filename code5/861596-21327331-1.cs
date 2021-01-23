     List<Task> lst_tsk = new List<Task>();
            List<int> lst_item = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var item in lst_item)
            {
                var value = item;
                Task tsk = new Task(() =>
                {
                    Console.WriteLine(value);
                });
                lst_tsk.Add(tsk);
                tsk.Start();
            }
            foreach (var t in lst_tsk)
            {
                if (t.IsCompleted == false)
                    t.Wait();
            }
