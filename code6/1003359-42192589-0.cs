    public static ExcelRangeBase LoadFromCollection<T>(this ExcelRangeBase @this, 
        IEnumerable<T> collection, string[] propertyNames, bool printHeaders) where T:class
    {
        MemberInfo[] membersToInclude = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p=>propertyNames.Contains(p.Name))
                .ToArray();
        return @this.LoadFromCollection<T>(collection, printHeaders, 
                OfficeOpenXml.Table.TableStyles.None, 
                BindingFlags.Instance | BindingFlags.Public, 
                membersToInclude);
    }
