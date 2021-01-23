    public static void BusinessObjectConverter<TTarget, TSource>(this TTarget target, TSource source)
        {
            //Lesen aller Properties auf der ersten Ebene
            var targetProperties = typeof(TTarget)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(prop => prop.CanWrite);
            //Lesen aller Properties auf der ersten Ebene
            var sourceProperties = typeof(TTarget)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(prop => prop.CanWrite);
            //Loop durch alle Properties
            foreach (var item in targetProperties.Intersect(sourceProperties))
            {
                //Leere Werte duerfen nicht geschrieben werden
                if (!string.IsNullOrEmpty(source.GetType().GetProperty(item.Name).GetValue(source, null).ToString()))
                {
                    //Befuellen der Properties im Zielobjekt
                    item.SetValue(target, ValueConverter.ConvertValue(
                        source.GetType().GetProperty(item.Name).GetValue(source, null),
                        item.PropertyType),
                        null);
                }
            }
        }
