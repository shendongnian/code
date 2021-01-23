        public static class IVsFindSymbolExtensions
        {
            public static void DoSearch(this IVsFindSymbol findSymbol, Guid symbolScope, VSOBSEARCHCRITERIA2 criteria)
            {
                if (findSymbol == null)
                    throw new ArgumentNullException("findSymbol");
                VSOBSEARCHCRITERIA2[] criteriaArray = { criteria };
                ErrorHandler.ThrowOnFailure(findSymbol.DoSearch(ref symbolScope, criteriaArray));
            }
        }
