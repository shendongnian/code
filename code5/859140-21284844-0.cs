        public static class DestinationHelper
        {
            public static string GetDestinationSepcificImplm(Manager x)
            {
                return @"\ManagerHome";
            }
    
            public static string GetDestinationSepcificImplm(Accountant x)
            {
                return @"\AccountantHome";
            }
    
            public static string GetDestinationSepcificImplm(Cleaner x)
            {
                return @"\CleanerHome";
            }
        }
    
       class Program
        {
            static string GetDestination(Role x)
            {
    
                #region Other Common Works
                //Do logging
                //Other Business Activities
                #endregion
    
                string destination = String.Empty;
                dynamic inputRole = x;
                destination = DestinationHelper.GetDestinationSepcificImplm(inputRole);
                return destination;
            }
    
            static void Main(string[] args)
            {
                string destination = GetDestination(new Security());
                Console.WriteLine(destination);
                Console.WriteLine("....");
                Console.ReadLine();
            }
    
        }
