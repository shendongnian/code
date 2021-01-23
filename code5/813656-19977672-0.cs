        public async Task<int> GetFirstToRespondAsync()
        {
            // Call two web services; take the first response.
            Task<int>[] tasks = new[] { Task1(), Task2() };
            // Await for the first one to respond.
            Task<int> firstTask = await Task.WhenAny(tasks);
            // Return the result.
            return await firstTask;
        }
        private async Task<int> Task1()
        {
            await Task.Delay(3000);
            return 3000;
        }
        private async Task<int> Task2()
        {
            await Task.Delay(1000);
            return 1000;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int i;
            i= await GetFirstToRespondAsync();
            MessageBox.Show(i.ToString());
        }
