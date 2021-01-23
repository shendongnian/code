            int[] array = new int[] { 8, 9, 5, 6, 7, 4, 3, 2, 1 };
            int[] outPut = new int[] { };
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    var first = array[i];
                    var second = array[j];
                    if (array[i] < array[j]) {
                        temp = first;
                        array[i] = second;
                        array[j] = temp;
                    }
                }
            }
            foreach (var item in array) {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            }
            foreach (var item in array) {
                Console.WriteLine(item);
            }
            Console.ReadKey();
