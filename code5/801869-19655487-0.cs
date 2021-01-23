        private async void Foo()
        {
            Console.WriteLine("Going to Await");
            await Task.Delay(5000);
            Console.WriteLine("Done with awaiting");
        }
