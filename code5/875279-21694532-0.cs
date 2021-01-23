    class Program
    {
        static void Main(string[] args)
        {
            var adAdFields = new List<AdAdField>
            {
                new AdAdField {colorId = 109, optionsId = 303, provinceId = 202},
                new AdAdField {colorId = 145, optionsId = 309, provinceId = 2},
                new AdAdField {colorId = 3, optionsId = 317, provinceId = 3},
                new AdAdField {colorId = 4, optionsId = 318, provinceId = 4}
            }.AsQueryable();
    
            var matchConditions = new long[][] 
                { 
                    new long[] { 109, 145 }, //color Id
                    new long[] { 202 }, // province Id
                    new long[] { 303, 309, 317, 318 }, //options Id
                };
    
            var result1 = adAdFields.Where(x => matchConditions[0].Contains(x.colorId)
                                  && matchConditions[1].Contains(x.provinceId)
                                  && matchConditions[2].Contains(x.optionsId)).ToList();
    
            var query = adAdFields;
    
            if (matchConditions[0].Length > 0)
                query = query.Where(x => matchConditions[0].Contains(x.colorId));
    
            if (matchConditions[1].Length > 0)
                query = query.Where(x => matchConditions[1].Contains(x.provinceId));
    
            if (matchConditions[2].Length > 0)
                query = query.Where(x => matchConditions[2].Contains(x.optionsId));
            //below will be other possible conditions....
    
    
            var result2 = query.ToList();
            //result2 and result1 ARE SAME!!!
        }
    }
    
    public class AdAdField
    {
        public int colorId { get; set; }
        public int provinceId { get; set; }
        public int optionsId { get; set; }
    }
