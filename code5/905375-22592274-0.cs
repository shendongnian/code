        public class CategoryGetAllBySearchDto
            {
                public int? Id { get; set; }
                public string Name { get; set; }
                public int SearchCount { get {  return this.Ids.Count() } }
                public IEnumerable<int> Ids { get; set; }
            }
