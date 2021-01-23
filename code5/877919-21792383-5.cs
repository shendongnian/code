    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class GroupByDemo
    {
        static public void Main(string[] args)
        {
            var actions = new List<ActionToDo>()
                {
                    new ActionToDo("AQ.14b", "2014-02-14", "AQ", "Desc.AQ.14"),
                    new ActionToDo("AQ.12a", "2014-02-12", "AQ", "Desc.AQ.12"),
                    new ActionToDo("AQ.13b", "2014-02-13", "AQ", "Desc.AQ.13"),
                    new ActionToDo("XX.01",  "2014-02-01", "XX", "Desc.XX.01"),
                    new ActionToDo("AQ.14a", "2014-02-14", "AQ", "Desc.AQ.14"),
                    new ActionToDo("AQ.12b", "2014-02-12", "AQ", "Desc.AQ.12"),
                    new ActionToDo("AQ.13a", "2014-02-13", "AQ", "Desc.AQ.13"),
                    new ActionToDo("XX.02",  "2014-02-02", "XX", "Desc.XX.02"),
                    new ActionToDo("AQ.13c", "2014-02-13", "AQ", "Desc.AQ.13"),
                    new ActionToDo("XX.03",  "2014-02-03", "XX", "Desc.XX.03")
                };
    
            var results =
                from a in actions
                where a.EventCode == "AQ"
                orderby a.dtDate, a.EventDescription, a.Name
                group a by new { a.dtDate, a.EventDescription };
    
            foreach (var group in results)
            {
                Console.WriteLine("[{0}] [{1}]",
                                  group.Key.dtDate.ToString("yyyy-MM-dd"),
                                  group.Key.EventDescription);
    
                foreach (var action in group)
                {
                    Console.WriteLine("  {0}", action.Name);
                }
            }
        }
    }
    
    class ActionToDo
    {
        public string Name {get;set;}
        public DateTime dtDate {get;set;}
        public string EventCode {get;set;}
        public string EventDescription {get;set;}
    
        public ActionToDo(
            string name,
            string dtDateString,
            string eventCode,
            string eventDescription)
        {
            this.Name = name;
            this.dtDate = DateTime.Parse(dtDateString);
            this.EventCode = eventCode;
            this.EventDescription = eventDescription;
        }
    }
