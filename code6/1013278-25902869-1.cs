    private IEnumerable<AttributeResourceModelSubItem> FormatAttributes(IEnumerable<Attribute> attributes)
    {
        return attributes.GroupBy(c => c.name)
                         .Select(c => new AttributeResourceModelSubItem()
                                      {
                                          key = c.Key,
                                          values = c.Select((item, index) => new AttributeValueResourceModelSubItem()
                                                                 {
                                                                     id = index + 1,
                                                                     name = item.value
                                                                 }).ToList();
                                      });
    }
