        public void test()
        {
            for (var i = 0; i < 10000; i++)
            {
                // create object
                var animal = new Animal {Name = "test" + i};
                // invoke list.Add on the UI thread
                this.Dispatcher.Invoke(new Action(() => list.Add(animal)));
                // sleep
                System.Threading.Thread.Sleep(1);
            }
        }
