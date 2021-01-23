        [InjectLambda]
        public static bool SearchTermMatch(List<string> termlist, List<string> fieldvalues)
        {
            throw new NotImplementedException();
        }
        public static Expression<Func<List<string>, List<string>, bool>> SearchTermMatch()
        {
            return (t,f) => 
            (
                (t.Count() == 0) ||
                (t.Count(_t => f.Any(_f => _f.Contains(_t)) || _t == "") == t.Count())
            );
        }
        
