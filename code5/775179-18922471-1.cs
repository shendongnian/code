    class ClassicVisitor : IAVisitor
        {
            public string SuperComplexStringResult { get;set; }
            public void Visit(B b) { SuperComplexStringResult = String.Format("Super Complex Stuff + {0}", b.PropertyB); }
            public void Visit(C c) { SuperComplexStringResult = String.Format("Super Complex Stuff + {0}", c.PropertyC); }
        }
