         CalorieIngestion()
            {
        
            Console.WriteLine("What is your name?");
                    sName = Console.ReadLine();
                    Console.WriteLine("What day is it 1-8?");
                    sDay = Convert.ToString(Console.ReadLine());
                    if (sDay == "1")
                    {
                        CalorieCount(sName, sDay);
                    }
        
            }
          static void CalorieCount(string psDay, string psName)
            { int iCal1;
            Console.Clear();
            Console.WriteLine("Please enter the amount ingested");
            iCal1 = Convert.ToInt32(Console.ReadLine());
            using (StreamWriter sw = new StreamWriter(psName + ".txt", true))
            {
            sw.WriteLine("Calories consumed on " + psDay + "" + iCal1);
            }
    return;
