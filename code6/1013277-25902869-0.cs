    private IEnumerable<AttributeResourceModelSubItem> FormatAttributes(IEnumerable<Attribute> attributes)
    {
        return attributes.GroupBy(c => c.Id)
                         .Select(c => new AttributeResourceModelSubItem()
                                      {
                                          key = c.First().Name,
                                          values = c.Select(x => new AttributeValueResourceModelSubItem()
                                                                 {
                                                                     id = 1,
                                                                     name = x.value
                                                                 }).ToList();
                                      });
    }
