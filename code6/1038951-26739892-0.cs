    int choice = 0;
    int balance = 100;
    while (choice != 1) {
        Console.WriteLine("Enter withdraw amount");
        string userInput = Console.ReadLine();
        
        // This will crash the program if the user enters text.
        // Used for demonstration only. int.TryParse is preferred.
        int value = int.Parse(userInput);
        
        choice = AccountTest.DebitTest(balance, value);
    }
    class AccountTest {
        public static int DebitTest(int AccountBalance, int WithdrawalAmount)
        {
            // do the test if the debit is OK
            //..........
            
            // At the end, you can do this. This till return the value entered and 
            // choice will be given a new value. If it was 1, the program will end.
            // NOTE: It's not safe to use convert as                
            // it will crash the program if the user enters text.
            return Convert.ToInt32(Console.ReadLine()); 
        }
            
    }
