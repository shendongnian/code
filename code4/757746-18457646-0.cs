        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem((o) =>
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
