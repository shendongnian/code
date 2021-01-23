    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverFlowConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                List<PaymentRates_VisaImmigrationPermit> PaymentRates_VisaImmigrationPermits = new List<PaymentRates_VisaImmigrationPermit>() { 
                new PaymentRates_VisaImmigrationPermit(){HomeCountryId= new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28a"),HostCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28a")},
                new PaymentRates_VisaImmigrationPermit(){HomeCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28b"),HostCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28b")}
                };
                List<allCountryCombination> allCountryCombinations = new List<allCountryCombination>() {             
                new allCountryCombination(){HomeCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28b"),HostCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28b")},
                new allCountryCombination(){HomeCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28c"),HostCountryId=new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28c")}
                };
    
                var allCountryRates = (from r in PaymentRates_VisaImmigrationPermits where allCountryCombinations.Any(c => c.HomeCountryId == r.HomeCountryId && c.HostCountryId == r.HostCountryId) select r).FirstOrDefault();
    
                int sa = 0;
            }
    
            class PaymentRates_VisaImmigrationPermit
            {
                public Guid? HomeCountryId { get; set; }
    
                public Guid? HostCountryId { get; set; }
            }
    
            class allCountryCombination
            {
                public Guid HomeCountryId { get; set; }
    
                public Guid HostCountryId { get; set; }
            }
           
        }
    }
