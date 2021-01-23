    IEnumerable<QuantityDate> quantityDates = GetQuantityDates();//I'm sure you already have some way of retrieving these, via EF or Linq to SQL etc.
    var results = quantityDates.Where(qd => qd < 0).CombineResults(); //This is the main Linq expression
    
    //This is where the magic happens, and we combine the results
    public List<OutOfStockRange> CombineResults(IEnumerable<QuantityDate> input)
    {
        List<OutOfStockRange> output=new List<OutOfStockRange>();
        OutOfStockRange lastEntered = null;
        foreach(var qd in input.OrderBy(qd => qd.EventDate)
         {
             if(lastEntered != null && lastEntered.AddDays(1) == qd.EventDate)
             {
                 lastEntered.ToDate = qd.EventDate;
             }
             else
             {
                 lastEntered =new OutOfStockRange(){FromDate = qd.EventDate, ToDate = qd.EventDate}
                 output.Add(lastEntered);
             }
        }
    }
    
    return output;
    }
    
    //This class represents the input data
    public class QuantityDate
    {
        public DateTime EventDate {get; set;}
        public int Qty {get; set;}
    }
    //This class represents the output data
    public class OutOfStockRange
    {
        public DateTime FromDate {get; set;}
        public DateTime ToDate {get; set;}
    }
