        private static List<Industry> GetAllIndustries(Industry ind)
        {
            var result = new List<Industry>();
            result.Add(ind);
            foreach (var item in ind.ChildIndustries)
            {
                result.AddRange(GetAllIndustries(item));
            }
            return result;
        }
        private static IndustryNode[] GetChildIndustries(Industry i)
        {
            IndustryNode[] childs = new IndustryNode[i.ChildIndustries.Count];
            int k = 0;
            foreach (Industry ii in i.ChildIndustries)
            {
                childs[k++] = new IndustryNode()
                {
                    IndustryName = ii.IndustryName,
                    Hits = counts[ii],
                    ChildIndustryNodes = GetChildIndustries(ii)
                };
            }
            return childs;
        }
        private static Dictionary<Industry, int> counts;
        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>();
            //...
            List<Industry> allIndustries = companies.SelectMany(c => GetAllIndustries(c.Industry)).ToList();
            counts = allIndustries.Distinct().ToDictionary(e => e, e => allIndustries.Count(i => i == e));
            var listTop = allIndustries.Distinct().Where(i => i.ParentIndustry == null)
                            .Select(i =>  new IndustryNode()
                                    {
                                        ChildIndustryNodes = GetChildIndustries(i),
                                        Hits = counts[i],
                                        IndustryName = i.IndustryName
                                    }
                            );
        }
