        static void main()
        {
            var generator = new MyWorkGenerator();
            var consumers = new Thread[20];
            for (int i = 0; i < consumers.Length; i++)
            {
                consumers[i] = new Thread(DoWork);
                consumers[i].Start(generator);
            }
            
            generator.Produce();
        }
        public static void DoWork(object state)
        {
            var generator = (MyWorkGenerator) state;
            var workItem = generator.Consume(TimeSpan.FromHours(1));
            while (workItem != null)
            {
                // do work
                workItem = generator.Consume(TimeSpan.FromHours(1));
            }
        }
