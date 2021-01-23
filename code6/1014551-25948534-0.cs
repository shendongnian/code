            List<Store> stores = new List<Store>();
            foreach (string line in File.ReadAllLines(@"C:\Store.txt"))
            {
            var storeTemp = new Store();
                if (line.Contains("Store ID: "))
                    storeTemp.ID = line.Substring(10);
                if (line.Contains("Name: "))
                    storeTemp.name = line.Substring(6);
                if (line.Contains("Branch Number: "))
                    storeTemp.branchNO = Convert.ToInt32(line.Substring(15));
                if (line.Contains("Address: "))
                    storeTemp.address = line.Substring(9);
                if (line.Contains("Phone: "))
                {
                    storeTemp.phoneNumber = Convert.ToInt32(line.Substring(7));
                    stores.Add(storeTemp);
                }
            }
