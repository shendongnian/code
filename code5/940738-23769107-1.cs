    class Vba1DRange : IEnumerable<double> {
        private Array arr;
        public Vba1DRange(object vba) {
            arr = (Array)vba;
        }
        public double this[int index] {
            get { return Convert.ToDouble(arr.GetValue(index + 1, 1)); }
            set { arr.SetValue(value, index + 1, 1); }
        }
        public int Length { get { return arr.GetUpperBound(0); } }
        public IEnumerator<double> GetEnumerator() {
            int upper = Length;
            for (int index = 0; index < upper; ++index)
                yield return this[index];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
