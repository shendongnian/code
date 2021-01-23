        public class CardComparer : IEqualityComparer<Card>
        {
            public bool Equals(Card x, Card y) { return x.ID == y.ID; }
            public int GetHashCode(Card obj) { return obj.ID; }
        }
        var hash = new HashSet<Card>(new CardComparer());
