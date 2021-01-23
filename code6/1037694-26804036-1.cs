    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    
    public class MyEventLog : EventLog {
        public MyEventLog() { }
        public MyEventLog(IContainer container) : this() { container.Add(this); }
    }
