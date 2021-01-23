        private static IEnumerable<Industry> GetAllIndustries(Industry ind)
        {
            yield return ind;
            foreach (var item in ind.ChildIndustries)
            {
                foreach (var inner in GetAllIndustries(item))
                {
                    yield return inner;
                }
            }
        }
        private static IndustryNode[] GetChildIndustries(Industry i)
        {
            return i.ChildIndustries.Select(ii => new IndustryNode()
            {
                IndustryName = ii.IndustryName,
                Hits = counts[ii],
                ChildIndustryNodes = GetChildIndustries(ii)
            }).ToArray();
        }
        private static Dictionary<Industry, int> counts;
        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>();
            //...
            var allIndustries = companies.SelectMany(c => GetAllIndustries(c.Industry)).ToList();
            HashSet<Industry> distinctInd = new HashSet<Industry>(allIndustries);
            counts = distinctInd.ToDictionary(e => e, e => allIndustries.Count(i => i == e));
            var listTop = distinctInd.Where(i => i.ParentIndustry == null)
                            .Select(i =>  new IndustryNode()
                                    {
                                        ChildIndustryNodes = GetChildIndustries(i),
                                        Hits = counts[i],
                                        IndustryName = i.IndustryName
                                    }
                            );
        }
