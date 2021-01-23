    Task f = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    //This would make the form become responsive every 500 ms
                    Thread.Sleep(500); //Makes the async thread sleep for 500 ms
                    Application.DoEvents(); //Updates the Form's UI
                }
            });
