        public interface ISelection<out T>
        {
            T Skip(int n);
            T Method2();
            T Method3();
            T Method4();
            T SpecialMethod();
        }
