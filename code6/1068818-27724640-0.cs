        private void HandleJob( params string[] value )
        {
            return;
        }
    
        [TestMethod]
        public async Task StartTest()
        {
            var task1 = Task.Run( () => HandleJob( "one" ) );
            var task2 = Task.Run( () => HandleJob( "two" ) );
            await Task.WhenAll( task1 , task2 );
        }
