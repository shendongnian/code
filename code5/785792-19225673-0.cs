                var task1 = new Task(() => results[0] = 0,
                    TaskCreationOptions.AttachedToParent);
                var task2 = new Task(() => results[1] = 1,
                    TaskCreationOptions.AttachedToParent);
                var task3 = new Task(() => results[2] = 2,
                    TaskCreationOptions.AttachedToParent);
                task1.Start();
                task2.Start();
                task3.Start();
                task1.Wait();
                task2.Wait();
                task3.Wait();
