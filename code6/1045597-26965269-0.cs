        //eg: symbol.IsFullNameEquals("List`1", "Generic", "Collections", "System");
        internal static bool IsFullNameEquals(this ISymbol symbol, params string[] fullNames) {
            if (symbol == null) throw new ArgumentNullException("symbol");
            if (fullNames == null || fullNames.Length == 0) throw new ArgumentNullException("fullNames");
            var idx = 0;
            for (; symbol != null; symbol = symbol.ContainingSymbol) {
                var name = symbol.MetadataName;
                if (string.IsNullOrEmpty(name)) break;
                if (idx == fullNames.Length) return false;
                if (name != fullNames[idx]) return false;
                idx++;
            }
            return idx == fullNames.Length;
        }
        //eg: var idx = symbol.MatchFullName(new []{"List`1", "Dictionary`2"}, new []{"Generic", "Collections", "System"});
        //return value: -1: none; 0: symbol is List`1; 1: symbol is Dictionary`2 
        internal static int MatchFullName(this ISymbol symbol, string[] typeNames, string[] outerFullNames) {
            if (symbol == null) throw new ArgumentNullException("symbol");
            if (typeNames == null || typeNames.Length == 0) throw new ArgumentNullException("typeNames");
            var fullLength = 1 + (outerFullNames != null ? outerFullNames.Length : 0);
            int idx = 0, result = -1;
            for (; symbol != null; symbol = symbol.ContainingSymbol) {
                var name = symbol.MetadataName;
                if (string.IsNullOrEmpty(name)) break;
                if (idx == fullLength) return -1;
                if (idx == 0) {
                    for (var i = 0; i < typeNames.Length; i++)
                        if (name == typeNames[i]) {
                            result = i;
                            break;
                        }
                    if (result == -1) return -1;
                }
                else {
                    if (name != outerFullNames[idx - 1]) return -1;
                }
                idx++;
            }
            if (idx == fullLength) return result;
            return -1;
        }
