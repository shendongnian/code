    public abstract class WordFacadeBase<T1, T2, T3, T4> : IWordFacade<T1, T2, T3, T4> {
        public abstract T1 DoSomething(T2 value);
        object IWordFacade.DoSomething(object value) {
            return DoSomething(T2)value);
        }
    }
