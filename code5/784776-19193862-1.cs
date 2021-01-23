        struct GenericPoint<T>
        {
            public static IMath<T> TMath { get; set; }
            public T x;
            public T y;
            public static GenericPoint<T> operator +(GenericPoint<T> p1, GenericPoint<T> p2)
            {
                GenericPoint<T> r;
                r.x = TMath.Add(p1.x, p2.x);
                r.y = TMath.Add(p1.y, p2.y);
                return r;
            }
        }
