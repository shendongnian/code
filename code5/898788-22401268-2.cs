        public bool Match<A, B>(A a, B b)
        {
            // Match code
            return true;
        }
        public C Create<A, B, C>(A a, B b)
        {
            // Create new record
            return default(C);
        }
        public IList<C> Join<A, B, C>(IList<A> a, IList<B> b)
        {
            if(!a.Any() || !b.Any()) return new List<C>();
            var aHead = a[0];
            var bMatches = b.Where(bEl => Match(aHead, bEl));
            var newCs = bMatches.Select(bEl => Create<A, B, C>(aHead, bEl)).ToList();
            newCs.AddRange(Join<A, B, C>(a.Skip(1).ToList(), b));  // Recursive call
            return newCs;
        }
