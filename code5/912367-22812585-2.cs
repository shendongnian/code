     if (propTypes[orderByColumn] == typeof(DateTime))
     {
           criteria.AddOrder(orderIsDesc
               ? Order.Desc(MyProjections.ConvertDate(
                                   Projections.Property(propNames[orderByColumn])))
               : Order.Asc(MyProjections.ConvertDate(
                                   Projections.Property(propNames[orderByColumn]))));
     }
