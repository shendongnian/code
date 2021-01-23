    public class InsuranceWithDetail
    {
        public InsuranceHeader { get; set; }
        public InsuranceDetail { get; set; }
    }
    public IEnumerable<InsuranceWithDetail> GetInsuranceList(int InsuranceHeaderId) 
    {
        var getData =from item in context.InsuranceHeader 
                  join item2 in context.InsuranceDetail
                  on item.InsuranceHeaderId equals item2.InsuranceDetailId
                  where item.InsuranceHeaderId == InsuranceHeaderId
                  select new InsuranceWithDetail { InsuranceHeader = item, InsuranceDetail = item2 };
        return getData;
    }
