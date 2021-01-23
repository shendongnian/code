     private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyMethod();
            MyMethod1();
        }
        public async Task MyMethod()
        {
            Task<int> longRunningTask = LongRunningOperation();
            //indeed you can do independent to the int result work here 
            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            MessageBox.Show(result.ToString());
        }
        public async Task MyMethod1()
        {
            Task<int> longRunningTask = SecondMethod();
            //indeed you can do independent to the int result work here 
            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            MessageBox.Show(result.ToString());
        }
        public async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            await Task.Delay(5000); //5 seconds delay
            return 1;
        }
        public async Task<int> SecondMethod()
        {
            await Task.Delay(2000);
            return 1;
        }
