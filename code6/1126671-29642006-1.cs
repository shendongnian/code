            MasterDataList.Add("key1", new List<string>() { "list1_item1", "list1_item2" });
            MasterDataList.Add("key2", new List<string>() { "list2_item1", "list2_item2" });
            MasterDataList.Add("key3", new List<string>() { "list3_item1", "list3_item2" });
            DepartmentList.Add("list1_item1");
            DepartmentList.Add("list1_item2");
            DepartmentList.Add("list2_item1");
            DepartmentList.Add("list2_item2");
            foreach (KeyValuePair<string, List<string>> item in MasterDataList)
            {
                foreach (var listItem in item.Value)
                {
                    if (!DepartmentList.Contains(listItem))
                        FailedList.Add(listItem);
                }
                
            }
            foreach (var item in FailedList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
