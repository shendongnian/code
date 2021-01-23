            int temp = 0;
            int[] arr = new int[] { 20, 65, 98, 71, 64, 11, 2, 80, 5, 6, 100, 50, 13, 9, 80, 454 };
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
