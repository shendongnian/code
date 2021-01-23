           int[] arr = new int[]{1,2,3,1,4,2,5,4};
            //create one loop for arr values
            for (int i = 0;  i < arr.Length; i++)
            {
                //create nested loop for compare current values with actual value of arr
                for (int j = i+1; j < arr.Length; j++)
                {
                    //and here we put our condition
                    if (arr[i] == arr[j])
                    {
                        Console.WriteLine(arr[i]);
                    }
                }
            }
