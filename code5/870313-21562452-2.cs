    class Something
    {
        string fACR = "BAK";
        int numbDays = 5;
    
        Public static void Main()
        {
            DateTime fileDate = GetFileDate(args);
    
            inFileName = "U:/CANSO/Engineering/Farms/" + fACR +
                "/DailyDownloads/";
            switch (fACR)
            {
                case "DEM":
                    inFileName = inFileName + "Report_Recombiner_" + fileDate.ToString("yyyy-MM-dd") + 
                        ".csv";
                    break;
                default:
                    inFileName = inFileName + "REPORT_Recombiner_" + fileDate.ToString("yyyy-M-d") + 
                        ".csv";
                    break;
            }
        }
        public static DateTime GetFileDate(string[] args)
        {
            try
            {
                fACR = args[0];
                numbDays = int.Parse(args[2]);
                return DateTime.Parse(args[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("INVALID COMMAND LINE ARGUMENTS! Follow Format:");
                Console.WriteLine("<farm_acronym> <yyyy-M-d> <# days>");
                Console.WriteLine(e);
                throw;
            }
        }
    }
