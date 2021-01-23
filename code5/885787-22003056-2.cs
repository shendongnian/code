        public virtual void HandleFindReferences()
        {
            int line;
            int col;
            // Get the caret position
            ErrorHandler.ThrowOnFailure( TextView.GetCaretPos( out line, out col ) );
            // Get the tip text at that location. 
            Source.BeginParse(line, col, new TokenInfo(), ParseReason.Autos, TextView, HandleFindReferencesResponse);
        }
        // this can be any constant value, it's just used in the next step.
        public const int FindReferencesResults = 100;
        void HandleFindReferencesResponse( ParseRequest req )
        {
            if ( req == null )
                return;
            // make sure the caret hasn't moved
            int line;
            int col;
            ErrorHandler.ThrowOnFailure( TextView.GetCaretPos( out line, out col ) );
            if ( req.Line != line || req.Col != col )
                return;
            IVsFindSymbol findSymbol = CodeWindowManager.LanguageService.GetService(typeof(SVsObjectSearch)) as IVsFindSymbol;
            if ( findSymbol == null )
                return;
            // TODO: calculate references as an IEnumerable<IVsSimpleObjectList2>
            // TODO: set the results on the IVsSimpleLibrary2 (used as described below)
            VSOBSEARCHCRITERIA2 criteria =
                new VSOBSEARCHCRITERIA2()
                {
                    dwCustom = FindReferencesResults,
                    eSrchType = VSOBSEARCHTYPE.SO_ENTIREWORD,
                    grfOptions = (uint)_VSOBSEARCHOPTIONS2.VSOBSO_LISTREFERENCES,
                    pIVsNavInfo = null,
                    szName = "Find All References"
                };
            findSymbol.DoSearch(new Guid(SymbolScopeGuids80.All), criteria);
        }
