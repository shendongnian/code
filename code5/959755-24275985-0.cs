    ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
            queue.Enqueue("http://link.jpg");
            for (var x = 0; x < 30; x++)
            {
                new Thread(new ThreadStart(() =>
                    {
                        //create webclient here
                        string uri;
                        while(queue.TryDequeue(out uri))
                        {
                            //download here
                        }
                    })).Start();
            }
