        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
           await Task.Factory.StartNew(() =>
                {
                    pipeline = new MyPipeline();
                    if (isRunning)
                    {
                        isRunning = false;
                        pipeline.PauseFaceLocation(true);
                        pipeline.Close();
                    }
                    else
                    {
                        isRunning = true;
                        pipeline.LoopFrames();
                    }
                });
        }
