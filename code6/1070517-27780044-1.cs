    class Program
    {
        public class Plan
        {
            public int ID { get; set; }
            public Plan Parent { get; set; }
            public int SomeOtherProperty { get; set; }
            // added to show we don't care about this
            public string IgnoreMe { get; set; }
            public Plan(int id, int other, Plan parent, string ignore)
            {
                this.ID = id;
                this.SomeOtherProperty = other;
                this.Parent = parent;
                this.IgnoreMe = ignore;
            }
            public override bool Equals(object obj)
            {
                Plan other = (Plan)obj;
                // just check the relevant properties
                return this.ID == other.ID
                    && this.SomeOtherProperty == other.SomeOtherProperty
                    && this.Parent == other.Parent;
                // .. or alternatively
                //return (new { ID, SomeOtherProperty, Parent })
                //    .Equals(new { other.ID, other.SomeOtherProperty, other.Parent });
            }
            // nicked from http://stackoverflow.com/a/4630550/1901857
            public override int GetHashCode()
            {
                return new { ID, SomeOtherProperty, Parent }.GetHashCode();
            }
            // just to help debug
            public override string ToString()
            {
                return string.Format("[ID: {0}, Other:{1}, Parent:{2}]", ID, SomeOtherProperty, Parent);
            }
        }
        static void Main(string[] args)
        {
            var parentPlans = new Plan[] {
                new Plan(101, 2, null, "parent1"),
                new Plan(102, 3, null, "parent2"),
                new Plan(103, 4, null, "parent3"),
                new Plan(104, 5, null, "parent4")
            };
            List<Plan> oldPlans = new List<Plan>(new Plan[] {
                new Plan(1, 2, parentPlans[0], "old1"),
                new Plan(2, 3, parentPlans[1], "old2"),
                new Plan(3, 4, parentPlans[2], "old3"),
                new Plan(4, 5, parentPlans[3], "old4")
            });
            List<Plan> newPlans = new List<Plan>(new Plan[] {
                new Plan(11, 2, parentPlans[0], "new1"), // different ID
                new Plan(2, 3, parentPlans[1], "new2"),  // same
                new Plan(3, 14, parentPlans[2], "new3"), // different other ID
                new Plan(4, 5, parentPlans[2], "new4")   // different parent
            });
            foreach (var e in
                oldPlans.Join(newPlans, o => o, n => n, (o, n) => new { Old = o, New = n }))
            {
                Console.WriteLine(e.Old + " / " + e.New);
            };
        }
    }
