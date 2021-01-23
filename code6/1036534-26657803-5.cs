    public static class DynamicJoinExtensions
    {
        public static IEnumerable<dynamic> DynamicJoin(this IEnumerable<MyTran> myTran, IEnumerable<YourTran> yourTran, params Tuple<string, string>[] keys)
        {
            var outerKeySelector = CreateFunc<MyTran>(keys.Select(k => k.Item1).ToArray());
            var innerKeySelector = CreateFunc<YourTran>(keys.Select(k => k.Item2).ToArray());
            return myTran.Join(yourTran, outerKeySelector, innerKeySelector, (c, d) => new
            {
                MyId = c.Id,
                YourId = d.Id,
                MyAmtUSD = c.MyAmountUSD,
                MyAmtGBP = c.MyAmountGBP,
                YourAmtUSD = d.YourAmountUSD,
                YourAmtGBP = d.YourAmountGBP
            }, new ObjectArrayComparer());
        }
        private static Func<TObject, object[]> CreateFunc<TObject>(string[] keys)
        {
            var type = typeof(TObject);
            return delegate(TObject o)
            {
                var data = new object[keys.Length];
                for(var i = 0;i<keys.Length;i++)
                {
                    var key = type.GetProperty(keys[i]);
                    if(key == null)
                        throw new InvalidOperationException("Invalid key: " + keys[i]);
                    data[i] = key.GetValue(o);
                }
                return data;
            };
        }
        private class ObjectArrayComparer : IEqualityComparer<object[]>
        {
            public bool Equals(object[] x, object[] y)
            {
                return x.Length == y.Length
                       && Enumerable.SequenceEqual(x, y);
            }
            public int GetHashCode(object[] o)
            {
                var result = o.Aggregate((a, b) => a.GetHashCode() ^ b.GetHashCode());
                return result.GetHashCode();
            }
        }
    }
