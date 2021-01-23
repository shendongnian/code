    public bool ContainsDuplicate(double[] nums) 
    {
                int size = nums.Length;
                HashSet<double> set1 = new HashSet<double>();
                for (int i = 0; i < size; i++)
                {
                    if (set1.Contains(nums[i]))
                    {
                        return true;
                    }
                    else
                    {
                        set1.Add(nums[i]);
                    }
                }
                return false;
    }
