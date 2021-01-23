    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace MyCollections
    {
        public class RecentQueue<T> : IEnumerable<T>
        {
            class RecentItem<T>
            {
                public T Item { get; set; }
                public DateTime Date { get; set; }
            }
            public TimeSpan Period { get; set; }
            private Queue<RecentItem<T>> _q;
            public RecentQueue(TimeSpan t)
            {
                Period = t;
                _q = new Queue<RecentItem<T>>();
            }
            public void Enqueue(T t)
            {
                Cut();
                _q.Enqueue(new RecentItem<T> { Date = DateTime.Now, Item = t });
            }
            public IEnumerator<T> GetEnumerator()
            {
                Cut();
                foreach (var element in _q)
                    yield return element.Item;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                Cut();
                foreach (var element in _q)
                    yield return element.Item;    
            }
            private void Cut()
            {
                var date = DateTime.Now;
                while (_q.Count > 0 && date - _q.Peek().Date > Period)
                    _q.Dequeue();
            }
        }
    }
