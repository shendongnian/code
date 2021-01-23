        public class Date
        {
            public int day, month, year;
        }
        public Date date = new Date();
        public double amount;
        public long acc_no;
        public string action;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transaction = new List<Transaction>();
            StreamReader sr = new StreamReader("transaction.csv");
            string data = sr.ReadLine();
            while (data != null)
            {
                string[] dataarray = data.Split(',');
                string[] date_split = dataarray[0].Split('-');
                
                Transaction tran_obj = new Transaction();
                tran_obj.date.day = int.Parse(date_split[0]);
                tran_obj.date.month = int.Parse(date_split[1]);
                tran_obj.date.year = int.Parse(date_split[2]);
                tran_obj.acc_no = long.Parse(dataarray[1]);
                tran_obj.amount = double.Parse(dataarray[2]);
                tran_obj.action = dataarray[3];
                transaction.Add(tran_obj);
                data = sr.ReadLine();
            }
            Console.WriteLine("Please enter the account number for which you are looking for");
            long new_acc_no = long.Parse(Console.ReadLine());
            foreach (Transaction t in transaction)
            {
                if (t.acc_no == new_acc_no)
                {
                    Console.WriteLine(t.amount);
                    Console.WriteLine(t.date);
                    Console.WriteLine(t.action);
                }
            }
            string s = Console.ReadLine();
        }
        string s = Console.ReadLine();
    }
     
