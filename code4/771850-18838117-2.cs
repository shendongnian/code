        [Test]
        [RequiresSTA]
        public async Task DoSomeUITest()
        {
            using (new StaSynchronizationContext())
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - " + Thread.CurrentThread.GetApartmentState());
                // *** await something here ***
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " - " + Thread.CurrentThread.GetApartmentState());
                new FrameworkElement();
            }
        }
