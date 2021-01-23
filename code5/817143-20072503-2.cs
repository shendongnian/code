           Task[]t = new Task[100];
            for (int i = 0; i < 100; i++)
            {
               t[i] = Task.Factory.StartNew(() => print(i));
            }
            Task.WaitAll(t);
   
