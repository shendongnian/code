    using System;
    using System.Configuration;
    
    namespace ExtendedKVP
    {
        class Program
        {
            static void Main(string[] args)
            {           
                var connectionManagerDataSection = ConfigurationManager.GetSection(RuleSection.SectionName) as RuleSection;
                if (connectionManagerDataSection != null)
                {
                    foreach (RuleElement element in connectionManagerDataSection.ConnectionManagerEndpoints)
                    {
                        Console.WriteLine(string.Format("RuleId: {0}, RuleActive: {1}, RuleDesc: {2}", element.RuleId, element.RuleActive, element.RuleDesc));                
                    }
                }
            }
        }
    }
