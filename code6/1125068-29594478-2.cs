    class Program
    {
        static void Main(string[] args)
        {
            BindingList<Client> listOne = new BindingList<Client>()
            {
                new Client { Name = "ClientName1" },
                new Client { Name = "ClientName2" },
                new Client { Name = "ClientName3" },
            };
            BindingList<Debt> listTwo = new BindingList<Debt>()
            {
                new Debt { AccountType = "AccountType1", DebtValue = 29 },
                new Debt { AccountType = "AccountType2", DebtValue = 31 },
                new Debt { AccountType = "AccountType3", DebtValue = 37 },
            };
            BindingList<Accounts> listThree = new BindingList<Accounts>()
            {
                new Accounts { Owner = "Owner1", AccountNumber = 17, IsChekingAccount = false },
                new Accounts { Owner = "Owner2", AccountNumber = 19, IsChekingAccount = true },
                new Accounts { Owner = "Owner3", AccountNumber = 23, IsChekingAccount = true },
            };
            LogList(listThree);
            listThree.SetValueByCoordinates(2, (int)AccountsProperty.IsChekingAccount, false);
            listThree.SetValueByCoordinates(1, (int)AccountsProperty.Owner, "My self");
            LogList(listThree);
            string result1 = (string)listOne.GetValueByCoordinates(0, (int)ClientProperty.Name);
            int result2 = (int)listTwo.GetValueByCoordinates(1, (int)DebtProperty.DebtValue);
            LogList(listOne);
            LogList(listTwo);
            Console.WriteLine("result1: " + result1);
            Console.WriteLine("result2: " + result2);
        }
        static void LogList<T>(BindingList<T> list)
        {
            foreach (T t in list)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
        }
    }
