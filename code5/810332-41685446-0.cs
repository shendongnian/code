        /*
        Description for a sample set {1, 2, 2, 3}:
        Step 1 - Start with {}:
        {}
        Step 2 - "Expand" previous set by adding 1:
        {}
        ---
        {1}
        Step 3 - Expand previous set by adding the first 2:
        {}
        {1}
        ---
        {2}
        {1,2}
        Step 4 - Expand previous set by adding the second 2:
        {}
        {1}
        {2}
        {1,2}
        ---
        {2}
        {1,2}
        {2,2}
        {1,2,2}
        Step 5 - Expand previous set by adding 3:
        {}
        {1}
        {2}
        {1,2}
        {2}
        {1,2}
        {2,2}
        {1,2,2}
        ---
        {3}
        {1,3}
        {2,3}
        {1,2,3}
        {2,3}
        {1,2,3}
        {2,2,3}
        {1,2,2,3}
        Total elements = 16 (i.e. 2^4), as expected.
        */
        private static void PowerSet(IList<int> nums, ref IList<IList<int>> output)
        {
            // ToDo: validate args
            output.Add(new List<int>());
            ExpandSet(nums, 0, ref output);
        }
        private static void ExpandSet(IList<int> nums, int pos, ref IList<IList<int>> output)
        {
            if (pos == nums.Count)
            {
                return;
            }
            List<int> tmp;
            int item = nums[pos];
            for (int i = 0, n = output.Count; i < n; i++)
            {
                tmp = new List<int>();
                tmp.AddRange(output[i]);
                tmp.Add(item);
                output.Add(tmp);
            }
            ExpandSet(nums, pos + 1, ref output);
        }
