    public class PrimesEnumerable : IEnumerable<int> {
        public PrimesEnumerable() {
            var ints = Enumerable.Range(2, Int32.MaxValue - 1);
            _internalEnumerable = ints.Where(x => !ints.TakeWhile(y => y < Math.Sqrt(x)).Any(y => x % y == 0));
        }
        public readonly IEnumerable<int> _internalEnumerable;
    
        public IEnumerator<int> GetEnumerator() {
            return _internalEnumerable.GetEnumerator();
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _internalEnumerable.GetEnumerator();
        }
    }
