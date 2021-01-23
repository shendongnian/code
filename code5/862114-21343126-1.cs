            // Inputs for Tests purpose
            List<string> values = new List<string> { "item1", "item2", "item1", "item1" };
            // Result data
            List<string> finalResult = new List<string>();
            // 1 - Group by item value
            var tempResult = from i in values
                             group i by i;
            // We loop over all different item name
            foreach (var curItem in tempResult)
            {
                // Thanks to the group by we know how many item with the same name exists
                for (int ite = 0; ite < curItem.Count(); ite++)
                {
                    if (ite == 0)
                        finalResult.Add(curItem.Key);
                    else
                        finalResult.Add(string.Format("{0} - {1}", curItem.Key, ite));
                }
            }
