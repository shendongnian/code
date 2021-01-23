        private async static void LoopForMe()
        {
            //Keep thread busy forever for the sake of the example
            int counter = 0;
            while (true)
            {
                //Define pauseTask as a static bool. You will flip this
                //when you want to pause the task
                if (pauseTask)
                {
                    await Task.Delay(100000);
                    pauseTask = false;
                }
                Debug.WriteLine("working... " + counter);
                counter++;
                //Do something forever
            }
        }
