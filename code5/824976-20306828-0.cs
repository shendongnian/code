        [TestMethod]
        public void ListCategories()
        {
            var staff = new List<Employee>();
            staff.Add(new InvestmentBanker {Name="Fred Goodwin", Department = "NW"});
            staff.Add(new InvestmentBanker {Name="Nick Leeson", Department = "Barings"});
            staff.Add(new Cleaner{ Name = "George Formby", Department="NW" });
            var sb = new StringBuilder();
            foreach (var e in staff)
            {
                sb.Append(string.Format(
                 "update Employee set PaymentBalance=PaymentBalance+{0}" + 
                 " where Name='{1}'\r\n", 
                 e.CategoryBonus, e.Name));                
            }
        }
    }
    public class Employee
    {
        public string Department { get; set; }
        public string Name { get; set; }
        public virtual string Category { get { return "Employee"; } }
        public virtual decimal CategoryBonus { get { return 0; } }
    }
    public class Cleaner:Employee
    {
        public override string Category {get { return "Cleaner"; }}
        public override decimal CategoryBonus{get { return 0.01M; }}
    }
    public class InvestmentBanker:Employee
    {
        public override string Category { get { return "Banker"; } }
        public override decimal CategoryBonus { get { return 999999999999999M; } }        
    }
