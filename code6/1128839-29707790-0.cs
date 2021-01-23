        public class Dad
        {
            public List<Kid> kids = new List<Kid>();
            public Dad(IEnumerable<Kid> kids)
            {
                this.kids = kids.ToList();
            }
        }
        public class Kid
        {
            public List<string> Toys = new List<string>();
            public Kid(IEnumerable<string> toys)
            {
                Toys = toys.ToList();
            }
        }
        var dads = new List<Dad> {
            new Dad(new [] { new Kid(new [] { "a", "b" }) }),
            new Dad(new [] { new Kid(new [] { "c", "d" }) }),
        };
        var dadsWithKidsWithChangeToysName = dads.Select(d => new Dad(d.kids.Select(k => new Kid(k.Toys.Select(t => t.ToUpper())))));
