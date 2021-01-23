        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                cTokenSource = new CancellationTokenSource();
                cToken = cTokenSource.Token;
                var producer = Producer();
                var consumer = Consumer();
                await Task.WhenAll(producer, consumer);
                Report();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.Read();
            }
        }
