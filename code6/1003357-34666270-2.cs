    public static class Extensions
    {
        public static ExcelRangeBase LoadFromCollectionFiltered<T>(this ExcelRangeBase @this, IEnumerable<T> collection) where T:class
        {
            MemberInfo[] membersToInclude = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p=>!Attribute.IsDefined(p,typeof(EpplusIgnore)))
                .ToArray();
            return @this.LoadFromCollection<T>(collection, false, 
                OfficeOpenXml.Table.TableStyles.None, 
                BindingFlags.Instance | BindingFlags.Public, 
                membersToInclude);
        }
        
    }
