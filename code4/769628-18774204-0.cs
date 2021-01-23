    ManagerSummary summary = new ManagerSummary();
    foreach (ListItem oListItem in collListItem)
    {
        FieldUserValue managerValue = (FieldUserValue)oListItem["Manager"];
        string managerId = managerValue.LookupId;
        double amount = Convert.ToDouble(oListItem["Amount"].ToString());
        summary.AddValue(managerId, amount);
    }
    foreach (var manager in summary.TopManagers(count))
    {
        Console.WriteLine(manager);
    }
        
    class ManagerSummary
    {
        Dictionary<string, Manager> _managers = new Dictionary<string, Manager>();
        public void AddValue(string managerId, double amount)
        {
            if (_managers.ContainsKey(managerId))
            {
                _managers[managerId].Total += amount;
            }
            else
            {
                _managers[managerId] = new Manager { Id = managerId, Total = amount };
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
        public double Total { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-5}{1,-10}", Id, Total);
        }
    }
