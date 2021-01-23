    public static Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8, T9>>
        Create(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, T9 t9)
    {
        return new Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8, T9>>
            (t1, t2, t3, t4, t5, t6, t7, Tuple.Create(t8, t9)); 
    }
