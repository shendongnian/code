        public SuperSimpleViewEngine(IEnumerable<ISuperSimpleViewEngineMatcher> matchers)
        {
            this.matchers = matchers ?? Enumerable.Empty<ISuperSimpleViewEngineMatcher>();
            this.processors = new List<Func<string, object, IViewEngineHost, string>>
            {
                PerformSingleSubstitutions,
                PerformContextSubstitutions,
                PerformEachSubstitutions,
                PerformConditionalSubstitutions,
                PerformPathSubstitutions,
                PerformAntiForgeryTokenSubstitutions,
                this.PerformPartialSubstitutions,
                this.PerformMasterPageSubstitutions,
            };
        }
