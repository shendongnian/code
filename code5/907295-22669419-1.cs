        private void Process(MyItem item, CancellationToken token)
        {
            try
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                
                ...sentences
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                ...more sentences
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                ...etc
            }
            catch(Exception ex)
                Console.WriteLine("Operation cancelled");
