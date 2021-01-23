    using System;
    using System.Linq;
    using System.Collections.Generic;
    ....
        private IEnumerable<T[]> Combine<T>(IEnumerable<T[]> data)
        {
            if (!data.Any())
                yield break;
            var head = data.First();
            var tail = Combine(data.Skip(1));
            foreach (var e in head)
            {
                var list = new T[] {e};
                if (!tail.Any())
                    yield return list;
                else
                {
                    foreach (var t in tail)
                    {
                        yield return list.Concat(t).ToArray();
                    }
                }
            }
        }
