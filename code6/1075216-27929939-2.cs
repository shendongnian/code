            private List<Accounts> accounts;
            public List<Accounts> Account
            {
                get { return accounts; }
                set
                {
                    accounts = value;
                    NotifyPropertyChanged("Accounts");
                }
            }
        
            void SetTree()
            {
                Account.Add(new Accounts { Header = "Accounts", IsReadOnly = true });
                Account[0].Account.Add(new Accounts { Header = "Product Type", Foreground = fGround, FontWeight = FontWeights.Bold, IsReadOnly = true });
                SortedSet<string> uniqueProductType = GetUniqueItems("Product Type");
                Accounts tempAccount;
                for (int i = 0; i < uniqueProductType.Count(); i++)
                {
                    tempAccount = new Accounts { Header = uniqueProductType.ElementAt(i), Foreground = fGround, FontWeight = FontWeights.Normal };
                    accountsSystemNode.Add(uniqueProductType.ElementAt(i), tempAccount);
                    tempAccount.Account.Add(new Accounts { Header = "Client Preferred Account Name", Foreground = fGround, FontWeight = FontWeights.Bold, IsReadOnly = true });
                    Account[0].Account[0].Account.Add(tempAccount);
                }
            }
