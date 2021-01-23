    class CustomType
    {
        public string Company { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; } 
    }
    var balance = bal.GroupBy(d => d.Compnay)
                     .Select(cl => new CustomType
                     {
                        Company = cl.Key,
                        Count = cl.Count(),
                        Amount = cl.Sum(c => c.Amount)
                     }).ToList();
