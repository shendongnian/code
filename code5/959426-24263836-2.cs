    public static Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>
        With(this Tuple<T1, T2, T3, T4, T5, T6, T7> tuple,
             TRest rest)
    {
        return new Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>(
            tuple.Item1, 
            tuple.Item2, 
            tuple.Item3, 
            tuple.Item4, 
            tuple.Item5, 
            tuple.Item6, 
            tuple.Item7,
            rest);
    }
