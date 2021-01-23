    public class MapProduction : ClassMap<Production>
    {
        public MapProduction()
        {
            CompositeId()
                .KeyProperty(c => c.ProductionCode, "P_PRO")
                .KeyProperty(c => c.Cycle, "C_CIC")
                .KeyProperty(c => c.Crop, "C_CUL")
                .KeyProperty(c => c.TechnologyLevel, "C_NVT");
            Map(c => c.Area).Column("A_ARE");
            Map(c => c.Productivity).Column("P_ARE");
            Map(c => c.syncStatus).ReadOnly();
        }
    }
