    public class LinkedItem<T1,T2_1,T2_2>
        where T1 : ChainEnum
        where T2_1 : ChainLinkEnum<T1>
        where T2_2 : ChainLinkEnum<T1>
    {
        public T1 LevelOne { get; set; }
        public T2_1 LevelTwoOne { get; set; }
        public T2_2 LevelTwoTwo { get; set; }
    }
