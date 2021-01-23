    public class AdvertPhotoMapping : BaseMapping<Advert> {
        public AdvertPhotoMapping() : base("AdvertPhoto") {
            Id(model => model.Advert)
                .Column("Id")
                .GeneratedBy.Foreign("Advert");
    
            Map(model => model.Description).Nullable();
            Map(model => model.Photo).CustomSqlType("image").Not.Nullable();
            HasOne(model => model.Advert).Constrained();
        }
    }
    public class AdvertMapping : BaseMapping<Advert> {
        public AdvertMapping() : base("Advert") {
            Id(model => model.Id).Not.Nullable().Unique().GeneratedBy.Identity();
            Map(model => model.Title).Not.Nullable().Length(100).Insert().Update();
            HasOne(x => x.AdvertPhoto).Cascade.All();
        }
    }
