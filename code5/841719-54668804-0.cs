     class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 2, 4, 5, 12, 2, 3, 3, 3, 12 };
            List<int> nums = new List<int>();
            List<int> count = new List<int>();
            nums.Add(arr[0]);
            count.Add(1);
            for (int i = 1; i < arr.Length; i++)
            {
                if(nums.Contains(arr[i]))
                {
                    count[nums.IndexOf(arr[i])] += 1;
                }
                else
                {
                    nums.Add(arr[i]);
                    count.Add(1);
                }
            }
            for(int x =0; x<nums.Count;x++)
            {
                Console.WriteLine("number:"+nums[x] +"Count :"+ count[x]);
            }
            Console.Read();
        }
    }
