        [Test]
        public async Task TestCorrect() //note the return type of Task. This is required to get the async test 'waitable' by the framework
        {
            await Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("Start");
                await Task.Delay(5000);
                Console.WriteLine("Done");
            }).Unwrap(); //Note the call to Unwrap. This automatically attempts to find the most Inner `Task` in the return type.
            Console.WriteLine("All done");
        }
