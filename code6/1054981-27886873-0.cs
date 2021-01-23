        public class SomeClass
        {
            public int X { get; set; }
            public int Y { get; set; }
            public void Test()
            {
                //Here I'm creating a List of Some class
                var someClassItems = new List<SomeClass> { 
                    new SomeClass { X = 1, Y = 1 }, 
                    new SomeClass { X = 2, Y = 2 } 
                };
                //Here I'm creating a Query
                //BUT, I'm not executing it, so the query variable, is represented by the IEnumerable object
                //and refers to an in memory query
                var query = someClassItems.
                    Select(o => o.X);
                //Only once the below code is reached, the query is executed.
                //Put a breakpoint in the query, click the mouse cursor inside the select parenthesis and hit F9
                //You'll see the breakpoint is hit after this line.
                var result = query.
                    ToList();
            }
        }
