    public class InsuranceWithDetail
    {
        public InsuranceHeader InsuranceHeader { get; set; }
        public InsuranceDetail InsuranceDetail { get; set; }
    }
    public IEnumerable<InsuranceWithDetail> GetInsuranceList(int InsuranceHeaderId) 
    {
        var results = from item in context.InsuranceHeader 
                      join item2 in context.InsuranceDetail
                         on item.InsuranceHeaderId equals item2.InsuranceDetailId
                      where item.InsuranceHeaderId == InsuranceHeaderId
                      select new InsuranceWithDetail 
                      { 
                          InsuranceHeader = item, 
                          InsuranceDetail = item2 
                      };
        // storing the results in a variable, will help on debugging. (quick watch)
        return results;
    }
