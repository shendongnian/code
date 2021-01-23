             // Inputs for Tests purpose
            List<string> values = new List<string> { "item1", "item2", "item1", "item1" };
            // Result data
            List<string> finalResult = new List<string>();
            values.GroupBy<string, string>(s1 => s1).ToList().ForEach(curItem =>
            {
                for (int ite = 0; ite < curItem.Count(); ite++)
                {
                    finalResult.Add(ite == 0 ? curItem.Key : string.Format("{0} - {1}", curItem.Key, ite));
                }
            });
