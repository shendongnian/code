    public class MapProduction : ClassMap<Production>
    {
        public MapProduction()
        {
            CompositeId()
                .KeyProperty(c => c.ProductionCode, "PROP_PRO")
                .KeyProperty(c => c.Cycle, "CODI_CIC")
                .KeyProperty(c => c.Crop, "CODI_CUL")
                .KeyProperty(c => c.TechnologyLevel, "CODI_NVT");
            Map(c => c.Area).Column("AREA_ARE");
            Map(c => c.Productivity).Column("PEST_ARE");
            Map(c => c.syncStatus).ReadOnly();
        }
    }
