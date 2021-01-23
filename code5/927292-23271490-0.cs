     [TestMethod]
            public void GetAAA() {
    
                var json = "{'BenACACalendarCycleId':2,'SelectionInverted':false,'Selection':[663],'_Selection':[663]}";
    
                EmployeeEligibilityFilter obj = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<EmployeeEligibilityFilter>(json); 
    
            }
    
            public class EmployeeEligibilityFilter
            {
                public int? BenACACalendarCycleId { get; set; }
                public bool SelectionInverted { get; set; }
                public List<int> Selection { get; set; }
                public List<object> _Selection { get; set; }
            }
