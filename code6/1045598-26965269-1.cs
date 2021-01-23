        //eg: symbol.IsFullNameEquals("List`1", "Generic", "Collections", "System")
        internal static bool IsFullNameEquals(this ISymbol symbol, params string[] nameParts) {
            if (symbol == null) throw new ArgumentNullException("symbol");
            if (nameParts == null || nameParts.Length == 0) throw new ArgumentNullException("nameParts");
            var idx = 0;
            for (; symbol != null; symbol = symbol.ContainingSymbol) {
                var name = symbol.MetadataName;
                if (string.IsNullOrEmpty(name)) break;
                if (idx == nameParts.Length) return false;
                if (name != nameParts[idx]) return false;
                idx++;
            }
            return idx == nameParts.Length;
        }
        //eg: var idx = symbol.MatchFullName(new []{"List`1", "Dictionary`2"}, new []{"Generic", "Collections", "System"});
        //return value: -1: none; 0: symbol is List`1; 1: symbol is Dictionary`2 
        internal static int MatchFullName(this ISymbol symbol, string[] typeNames, string[] outerNameParts) {
            if (symbol == null) throw new ArgumentNullException("symbol");
            if (typeNames == null || typeNames.Length == 0) throw new ArgumentNullException("typeNames");
            var fullLength = 1 + (outerNameParts != null ? outerNameParts.Length : 0);
            int idx = 0, result = -1;
            for (; symbol != null; symbol = symbol.ContainingSymbol) {
                var name = symbol.MetadataName;
                if (string.IsNullOrEmpty(name)) break;
                if (idx == fullLength) return -1;
                if (idx == 0) {
                    for (var i = 0; i < typeNames.Length; i++) {
                        if (name == typeNames[i]) {
                            result = i;
                            break;
                        }
                    }
                    if (result == -1) return -1;
                }
                else {
                    if (name != outerNameParts[idx - 1]) return -1;
                }
                idx++;
            }
            if (idx == fullLength) return result;
            return -1;
        }
