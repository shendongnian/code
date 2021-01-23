        public static List<List<int>> GetLists(int[] nums, bool strict) { 
            List<List<int>> lists = new List<List<int>>();
            List<int> list = new List<int>();
            lists.Add(list);
            list.AddRange(nums.Take(1));
            if (nums.Length <= 1) {
                return lists;
            }
            if (strict && nums[0] == nums[1]) {
                list = new List<int>();
                lists.Add(list);
                list.Add(nums[1]);
            }
            else
                list.Add(nums[1]);
            if (nums.Length == 2)
            {
                return lists;
            }
            int direction = Math.Sign(nums[2] - nums[1]);
            for (int i = 2; i < nums.Length; i++) {
                int d = Math.Sign(nums[i] - nums[i - 1]);
                if ((d == direction && (d != 0 || !strict))
                        || (d != 0 && strict)
                        || (Math.Abs(d + direction) == 1 && !strict))
                {
                    list.Add(nums[i]);
                    if (d != 0 && direction == 0) direction = d;
                }
                else
                {
                    direction = d;
                    list = new List<int>();
                    list.Add(nums[i]);
                    lists.Add(list);
                }
            }
            return lists;
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 2, 2, 1, 1, 3, 3, 4, 4 };
            var lists = GetLists(nums, false);
            foreach (var list in lists) {
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            /*
             * Prints:
             * 2 2 2 1 1
             * 3 3 4 4
             * */
        }
