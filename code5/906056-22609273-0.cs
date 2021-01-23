    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        public class AppLines { }
        public class AppAnnieImport : IEnumerator<AppLines>, IEnumerable<AppLines>
        {
            public int code { get; set; }
            public DateTime end_date { get; set; }
            public string vertical { get; set; }
            public string granularity { get; set; }
            public string device { get; set; }
            public List<AppLines> appLines { get; set; }
            private int position;
    
            AppLines IEnumerator<AppLines>.Current
            {
                get { return ((IEnumerator<AppLines>)this.appLines).Current; }
            }
    
            public void Dispose()
            {
                ((IEnumerator<AppLines>)this.appLines).Dispose();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.appLines.GetEnumerator();
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return ((System.Collections.IEnumerator)this.appLines).Current; }
            }
    
            public bool MoveNext()
            {
                return ((System.Collections.IEnumerator)this.appLines).MoveNext();
            }
    
            public void Reset()
            {
                ((System.Collections.IEnumerator)this.appLines).Reset();
            }
    
            IEnumerator<AppLines> IEnumerable<AppLines>.GetEnumerator()
            {
                return ((IEnumerable<AppLines>)this.appLines).GetEnumerator();
            }
        }
    }
