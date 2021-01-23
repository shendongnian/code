    public class TwoLevelItem<T1,T2>
        where T1 : ChainEnum
        where T2 : ChainLinkEnum<T1>
    {
        public T1 LevelOne { get; set; }
        public T2 LevelTwo { get; set; }
    }
