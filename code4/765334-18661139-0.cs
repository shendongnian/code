        public string GetDestinationPath(Type source, Type destination, string propertyName)
        {
            return GetDestinationPath(source, destination, propertyName, string.Empty);
        }
        public string GetDestinationPath(Type source, Type destination, string propertyName, string path)
        {
            var typeMap = Mapper.FindTypeMapFor(source, destination);
            if (typeMap == null)
                return null;
            var maps = typeMap.GetPropertyMaps();
            var exactMatch = maps.FirstOrDefault(m => m.SourceMember != null && m.SourceMember.Name == propertyName);
            if (exactMatch != null)
                return path + exactMatch.DestinationProperty.Name;
            foreach (var map in maps)
            {
                if (map.SourceMember == null)
                {
                    var result = GetDestinationPath(source, map.DestinationProperty.MemberType, propertyName, path + map.DestinationProperty.Name + ".");
                    if (result != null)
                        return result;
                }
                else
                {
                    if (!(map.SourceMember is PropertyInfo))
                        continue;
                    var result = GetDestinationPath((map.SourceMember as PropertyInfo).PropertyType, map.DestinationProperty.MemberType, propertyName, path + map.DestinationProperty.Name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
