         BlockingCollection<string> imageQueue=new BlockingCollection<string>();
            new Thread(() =>
            {
                foreach (string imagePath in imageQueue.GetConsumingEnumerable())
                {
                    ProcessImage(imagePath);
                }
            }).Start();
