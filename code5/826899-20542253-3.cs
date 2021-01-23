        using System;
        using System.Collections.Generic;
    
        public partial class Schedule
        {
            public Schedule()
            {
                this.OriginDependency = new HashSet<Dependency>();
                this.EndpointDependency = new HashSet<Dependency>();
            }
    
            public int ScheduleId { get; set; }
            public string ScheduleName { get; set; }
            public string Color { get; set; }
    
            public virtual ICollection<Dependency> OriginDependency { get; set; }
            public virtual ICollection<Dependency> EndpointDependency { get; set; }
        }
    }
