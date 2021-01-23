        interface IMath<T>
        {
            T Zero { get; }
            T One { get; }
            T Negate(T a);
            T Add(T a, T b);
            T Sub(T a, T b);
            T Mult(T a, T b);
            //etc...
        }
