    class A{
        public double X;
        public double Y;
        public A(double x, double y){
            X=x; Y=y;
        }
        public A(){
            // needs to have a no-arg constructor to satisfy new() constraint on MiddlePoint
        }
        public T MiddlePoint<T>(T[] a) where T : A, new() {
            T resultPnt = new T();
            for (int i = 0; i < a.Length; i++){
                resultPnt.X += a[i].X;
                resultPnt.Y += a[i].Y;
            }
            resultPnt.X = (this.X + resultPnt.X)/(a.Length + 1);
            resultPnt.Y = (this.Y + resultPnt.Y)/(a.Length + 1);
        }
    }
    class B:A{}
