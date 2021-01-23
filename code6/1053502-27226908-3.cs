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
    
         public double Level1
         {
             get
             {
                 double result;
                 if (double.TryParse(SpotLvl, out result))
                     return result;
                 else
                     return 0;
             }
         }
    
         public double Level2
         {
             get
             {
                 double result;
                 if (double.TryParse(VolLvl, out result))
                     return result;
                 else
                     return 0;
             }
         }
    
         public RiskData(string ccypair, string product, string spotlvl, string vollvl, double risk)
         {
             CcyPair = ccypair;
             Product = product;
             SpotLvl = spotlvl;
             VolLvl = vollvl;
             Risk = risk;
         }
    }
    
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                List<RiskData> risksObjects = Load();
    
    
    
    
            var result = risksObjects.GroupBy(g => new { g.Product, g.Level1, g.Level2 } )
                            .Select(
                                g => new { 
                                    Key = g.Key,
                                    Total = g.Sum(r => r.Risk)
                                }
                            )
                            .ToArray();
            foreach (var r in result)
                Console.WriteLine("Key: " + r.Key + ", Total: " + r.Total);
    
                Console.ReadLine();
    
            }
    
            static List<RiskData> Load()
            {
                var result = new List<RiskData>();
    
    //            INSTRUMENT  PORTFOLIO   PRODUCT LEVEL1  LEVEL2  VALUE
    
    result.Add(new RiskData("USDJPY","OPTION","100", "0.2",10000));
    result.Add(new RiskData("USDJPY","FWD","100", "0.2",3000));
    
    // just copy/pasted the above two lines a bunch in here...
    
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    result.Add(new RiskData("USDJPY", "OPTION", "100", "0.2", 10000));
    result.Add(new RiskData("USDJPY", "FWD", "100", "0.2", 3000));
    
    
    
                return result;
            }
        }
    }
