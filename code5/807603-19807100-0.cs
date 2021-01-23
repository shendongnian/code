        var Group = dt.AsEnumerable().GroupBy(x => x["CustomerLocation"].ToString()).ToDictionary(x => x.Key, x => x.ToList());
        foreach (var Items in Group)
        {
            int SumCustomerDebt = 0;
            
            foreach (var DistinctCustomerID in Items.Value.Select(x => x["CustomerID"].ToString()).Distinct())
            {
                var Instances = dt.AsEnumerable().Where(x => x[DistinctCustomerID] == DistinctCustomerID);
                foreach (var Instance in Instances)
                {
                    SumCustomerDebt += Convert.ToInt32(Instance["CustomerDebt"].ToString());
                }
            }
        }
