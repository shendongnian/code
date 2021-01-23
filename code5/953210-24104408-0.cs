    public FacilityTypeMap()
    {
        Table("CODES");
         
        // here we will use explicit runtime discriminator
        // injected by NHibernate into each SELECT .. FROM clause for this type
        Where(" TYPE_CODE = 'FACIL_TYPE' " )        
        Id(x => x.CodeValue).Column("CODE_CODE").GeneratedBy.Assigned();
        Map(x => x.Description).Column("DESCRIPTION");
        Map(x => x.OrderBy).Column("ORDER_BY");
        // no more inheritance
        // DiscriminateSubClassesOnColumn("TYPE_CODE", "INVALID")
        //    .SqlType("VARCHAR2");
    }
