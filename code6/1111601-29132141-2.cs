    //Task 1 - Create GSMCallHistoryTest class
    public class GSMCallHistoryTest
    {
      private theGSM;
      public void DisplayCallHistory()
      {
        //Create the calls
        DateTime testCallDate1 = new DateTime(2015, 03, 15, 17, 50, 23);
        DateTime testCallDate2 = new DateTime(2015, 03, 15, 20, 20, 05);
        DateTime testCallDate3 = new DateTime(2015, 03, 17, 11, 45, 00);
        var callHistory = new List<Call>
        {
          new Call(testCallDate1, 0889111111, 5),
          new Call(testCallDate2, 0889222222, 10),
          new Call(testCallDate3, 0889333333, 3)
        };
        //Tasks 2 and 3 - Create instance of theGSM and add the calls
        theGSM = new GSM("MODEL", "MANUFACTURER", callHistory);
        //Task 4 - Display information about the calls
        Console.WriteLine(theGSM.PrintCallHistory());
      }
    }
