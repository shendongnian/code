            List<int> list1 = new List<int> { 194, 195, 196, 197, 198, 199, 200 };
            List<int> list2 = new List<int> { 194, 200, 198, 195, 197, 196, 199 };
            list2.Sort();
            list1.Sort();
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] == list2[i])
                {
                    //Your Own processing logic here
                }
            }
