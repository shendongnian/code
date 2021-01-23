    Mapping.GroupBy(m => new
                         {
                             m.FieldName,
                             m.FieldType
                         })
           .Select(grp => new Field
                          {
                              FieldName = grp.Key.FieldName,
                              FieldType = grp.Key.FieldType,
                              FieldValue = string.Join(Environment.NewLine,
                                                       grp.Select(f => f.FieldValue))
                          });
