            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            var watch = new Stopwatch();
            int[] array = new int[500000000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }
            //warmup
            {
                watch.Restart();
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                    sum += array[i];
            }
            for (int i2 = 0; i2 < 5; i2++)
            {
                {
                    watch.Restart();
                    int sum = 0;
                    for (int i = 0; i < array.Length; i++)
                        sum += array[i];
                    Console.WriteLine("for loop:" + watch.ElapsedMilliseconds + "ms, result:" + sum);
                }
                {
                    watch.Restart();
                    fixed (int* ptr = array)
                    {
                        int sum = 0;
                        var length = array.Length;
                        for (int i = 0; i < length; i++)
                            sum += ptr[i];
                        Console.WriteLine("for loop:" + watch.ElapsedMilliseconds + "ms, result:" + sum);
                    }
                }
                {
                    watch.Restart();
                    fixed (int* ptr = array)
                    {
                        int sum1 = 0;
                        int sum2 = 0;
                        int sum3 = 0;
                        int sum4 = 0;
                        var length = array.Length;
                        for (int i = 0; i < length; i += 4)
                        {
                            sum1 += ptr[i + 0];
                            sum2 += ptr[i + 1];
                            sum3 += ptr[i + 2];
                            sum4 += ptr[i + 3];
                        }
                        Console.WriteLine("for loop:" + watch.ElapsedMilliseconds + "ms, result:" + (sum1 + sum2 + sum3 + sum4));
                    }
                }
                Console.WriteLine("===");
            }
