    class Program {
        static void Main(string[] args) {
    
            double[,] x = { { 1, 2, 3 }, { 4, 5, 6 } };
            double[,] y = { { 7, 8, 9 }, { 10, 11, 12 } };
    
            var xy = new StitchMatrix<int>(x, y);
    
            Console.WriteLine("0,0=" + xy[0, 0]); // 1
            Console.WriteLine("1,1=" + xy[1, 1]); // 5
            Console.WriteLine("1,2=" + xy[1, 2]); // 6
            Console.WriteLine("2,2=" + xy[2, 2]); // 9
            Console.WriteLine("3,2=" + xy[3, 2]); // 12
        }
    }
    
    class StitchMatrix<T> {
        private T[][,] _matrices;
        private double[] _lengths;
    
        public StitchMatrix(params T[][,] matrices) {
            // TODO: check they're all same size          
            _matrices = matrices;
    
            // call uperbound once for speed
            _lengths = _matrices.Select(m => m.GetUpperBound(0)).ToArray();
        }
    
        public T this[double x, double y] {
            get {
                // find the right matrix
                double iMatrix = 0;
                while (_lengths[iMatrix] < x) {
                    x -= (_lengths[iMatrix] + 1);
                    iMatrix++;
                }
                // return value at cell
                return _matrices[iMatrix][x, y];
            }
        }
    }
