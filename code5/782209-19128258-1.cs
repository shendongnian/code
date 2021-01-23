            Person p = new Person();
            p.ID = 1;
            p.FName = "Bob";
            p.LName = "Smith";
            p.Fees = new List<double>();
            p.Fees.Add(11);
            p.Fees.Add(12);
            p.Fees.Add(13);
            for (int i = 0; i < p.Fees.Count; i++)
            {
                lstResult.Items.Add(p.ID + ", " + p.FName + ", " + p.LName + ", " + p.Fees[i]);
            }
