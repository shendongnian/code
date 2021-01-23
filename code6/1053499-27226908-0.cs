    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication13
    {
        
    public class RiskData { 
         public string CcyPair { get; set; } 
         public string Product { get; set; } 
         public string SpotLvl { get; set; } 
         public string VolLvl { get; set; } 
         public double Risk { get; set; } 
    }
    
        class Program
        {
            static void Main(string[] args)
            {
                
                List<RiskData> risksObject = new List<RiskData>();
    
                // load data in some fashion
    
                var result = risksObject.GroupBy(g => g.Product)
                                .Select(
                                    g => new { RiskSum = g.Sum(rd => rd.Risk) }
                                )
                                .ToArray();
    
                                   
    
            }
        }
    }
