        public class MyProject 
        {     
            public IEnumerable<ISomething> ISomethings { get; set; }
            public IEnumerable<ISomething2> ISomethings2 {
                get { return this.ISomethings.Select(i => i.classB); }
            }
            public void RemoveSomething(ISomething2 s)
            {
                foreach (var somthing in this.ISomethings.Where(i => i.classB == s))
                {
                    somthing.classB = null;
                }
            }
        }
