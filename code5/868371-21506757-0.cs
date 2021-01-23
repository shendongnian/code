        public static IEnumerable<Row> GetAllChildIds(int parentId, List<Row> data)
        {
            var parents = data.Where(x => x.Id == parentId).ToList();
            return parents.Concat(parents.SelectMany(x => GetAllChildIds(x.ChildId, data)));
        }
