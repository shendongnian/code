    class MagicClass{ // don't have time for name-inventing :)
        private List<string> hashes = new List<string>();
        public string Hash {get{ return String.Join("_", hashes);}}
        public Func<TIn,bool> MagicWhere(Expression<Func<TIn,bool>> where){
            var v = new MagicExpressionVisitor();
            v.Visit(where);
            hashes.Add(v.ExpressionHash);
            return where.Compile(); // I think that should do...
        }
    }
    class MagicExpressionVisitor : ExpressionVisitor
    {
         public string ExpressionHash {get;set;}
         // Override ExpressionVisitor methods to get a possibly unique hash depending on what's actually in that expression
    }
