    ManagerSummary summary = new ManagerSummary();
    foreach (ListItem oListItem in collListItem)
    {
        FieldUserValue managerValue = (FieldUserValue)oListItem["Manager"];
        string managerId = managerValue.LookupId;
        string managerName = managerValue.LookupValue;
        double amount = Convert.ToDouble(oListItem["Amount"].ToString());
        summary.AddValue(managerId, managerName, amount);
    }
    foreach (var manager in summary.TopManagers(3))
    {
        Console.WriteLine(manager);
    }
        
    class ManagerSummary
    {
        Dictionary<string, Manager> _managers = new Dictionary<string, Manager>();
        public void AddValue(string managerId, string managerName, double amount)
        {
            if (_managers.ContainsKey(managerId))
            {
                _managers[managerId].Total += amount;
            }
            else
            {
                _managers[managerId] = new Manager { Id = managerId,  Name = managerName, Total = amount };
            }
        }
        public List<Manager> TopManagers(int count)
        {
            var managers = _managers.Values.ToList();
            return managers.OrderByDescending(x => x.Total).Take(count).ToList();
        }
        
    }
    class Manager
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-20}{1,-10}", Name, Total);
        }
    }
