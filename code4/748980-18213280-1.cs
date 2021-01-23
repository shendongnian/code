    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace ConsoleApp
    {
        public abstract class Flow
        {
            public virtual double Value { get { return new Random().Next() ; } }//these values are just for demonstration purposes
            public virtual DateTime Time
            {
                get
                {
                    return DateTime.MinValue.AddYears(1);
                }
            }
        }
    
        public class InboundFlow : Flow
        {
        }
    
        public class OutboundFlow : Flow
        {
        }
    
        public abstract class Fluent
        {
            IList<Flow> _flowCollection;
            public virtual IList<Flow> FlowCollection
            {
                get { return _flowCollection; }
                set { _flowCollection = value; }
            }
    
            private double _initialBaseflow;
            public virtual double InitialBaseflow
            {
                get { return _initialBaseflow; }
                set { _initialBaseflow = value; }
            }
    
            public Fluent()
            {
                FlowCollection = new List<Flow>();
            }
        }
    
        public class Affluent : Fluent
        {
            //public new virtual IList<InboundFlow> FlowCollection { get; set; }//Keep the property polymorphic
    
            public Affluent()
            {
                FlowCollection = new List<Flow>();
            }
        }
    
        public class Effluent : Fluent
        {
            //public new virtual IList<OutboundFlow> FlowCollection { get; set; }
    
            public Effluent()
            {
                FlowCollection = new List<Flow>();
            }
        }
    
        class Program
        {
            public static DateTime SOME_DATE { get { return DateTime.MinValue; } }
            public static DateTime SOME_OTHER_DATE { get { return DateTime.Now; } }
    
            static void Main(string[] args)
            {
                var inbound = new InboundFlow();
                var inbound2 = new InboundFlow();
                var outbound = new OutboundFlow();
                var a = new Affluent();            
                a.FlowCollection.Add(inbound);
                a.FlowCollection.Add(inbound2);
                FindInitialBaseflow(a);
            }
    
            private static void FindInitialBaseflow(Fluent fluent)
            {
                var linqFluent = fluent;
    
                var flows = linqFluent.FlowCollection.ToList().FindAll(
                            flow =>
                            flow.Time >= SOME_DATE &&
                            flow.Time < SOME_OTHER_DATE);
                var initialBaseflow = flows.Average(flow => flow.Value);
                fluent.InitialBaseflow = Math.Round(initialBaseflow, 5);
            }
        }
    }
