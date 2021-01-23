    public IEnumerable<dynamic> GetList()
            {
                var list = new List<int> {1, 2, 3, 4};
                return (from i in list
                       select new {
                           Integer = i,
                           Str = "Str" + i
                       }).ToList();
            }
