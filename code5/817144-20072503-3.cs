      Task[]t = new Task[100];
            for (int i = 0; i < 100; i++)
            {
               var temp=i;
               t[i] = Task.Factory.StartNew(() => print(temp));
            }
            Task.WaitAll(t);
