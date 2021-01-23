        void Process()
        {
            //for the sake of simplicity I am taking 1, in original implementation it is more than 1
            var cancellationToken = _cancellationTokenSource.Token;
            Task[] tArray = new Task[1];
            tArray[0] = Task.Factory.StartNew(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                //do some work here
                MainTaskRoutine(cancellationToken);
            }, cancellationToken);
            try
            {
                Task.WaitAll(tArray);
            }
            catch (Exception ex)
            {
                //do error handling here
            }
        }
        void MainTaskRoutine(CancellationToken cancellationToken)
        {
            //for the sake of simplicity I am taking 1, in original implementation it is more than 1
            //this method shows that a nested task is created 
            
            using (var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var cancelToken = cancellationTokenSource.Token;
                Task[] tArray = new Task[1];
                tArray[0] = Task.Factory.StartNew(() =>
                {
                    cancelToken.ThrowIfCancellationRequested();
                    //do some work here
                }, cancelToken);
                try
                {
                    Task.WaitAll(tArray);
                }
                catch (Exception ex)
                {
                    //do error handling here
                } 
            }
        }
