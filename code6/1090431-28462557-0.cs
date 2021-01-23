        Dictionary<string, List<int>> idNums = new Dictionary<string, List<int>>();
        foreach (DataRow myRow in dt.Rows)
        {
            string email = myRow["Email"].ToString()
            if (idNums.ContainsKey(email))
            {
                idNums[email].Add((int)myRow["CustomerID"]);
            }
            else
            {
                idNums.Add(email, new List<int> { (int)myRow["CustomerID"] });
            }
        }
