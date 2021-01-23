    public class Vw_EMIcount
    {
        public int EmiCount { get; set; }
        public string Satus { get; set; }
    }
    
    var result = context.Database.SqlQuery<Vw_EMIcount>("call EMIStatus('2018-3-01' ,'2019-05-30')").ToList();
