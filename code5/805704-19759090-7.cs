    [ActionName("StylesAll")]
    public AllStyles GetAllStyles()
    {
        return new AllStyles{
            Styles = from s in db.styles 
                     select new StyleDTO() { 
                         Name = s.Name, 
                         StyleId = s.StyleId },
            Labels = from l in db.Labels 
                     select new LabelDTO() { 
                         Name = l.Name, 
                         LabelId = l.LabelId , 
                         image = l.image},
            Commodities = from c in db.Commodities 
                          select new CommodityDTO() { 
                              CommodityId = c.CommodityId, 
                              CreateDate = c.CreateDate, 
                              Name = c.Name, 
                              Varieties = ( from v in c.Varieties 
                                            select new VarietyDTO() {
                                                CommodityId = v.CommodityId, 
                                                Name = v.Name, 
                                                VarietyId = v.VarietyId})}
        };
    }
