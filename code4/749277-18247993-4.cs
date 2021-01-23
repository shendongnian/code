      public class FiveLevelItem<T1,T2>
            where T1 : ChainEnum
            where T2 : ChainLinkEnum<T1>
            where T3 : ChainLinkEnum<T2>
            where T4 : ChainLinkEnum<T3>
            where T5 : ChainLinkEnum<T4>
    
        {
            public T1 LevelOne { get; set; }
            public T2 LevelTwo { get; set; }
            public T3 LevelThree { get; set; }
            public T4 LevelFour { get; set; }
            public T5 LevelFive { get; set; }
        }
