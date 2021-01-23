                Dictionary<string, List<TestObjs>> dict = new Dictionary<string, List<TestObjs>>();
            List<TestObjs> test = new List<TestObjs>();
            TestObjs obj = new TestObjs();
            obj.Name = "Test";
            test.Add(obj);
            dict.Add("Test 1", test);
            foreach (var entry in dict)
            {
                List<TestObjs> objs = entry.Value as List<TestObjs>;
                for (int i = objs.Count - 1; i >= 0; i--)
                {
                    if (objs[i].Name.Equals("Test"))
                    {
                        objs.RemoveAt(i);
                    }
                }
            }
