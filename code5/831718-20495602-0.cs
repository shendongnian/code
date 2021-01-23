    using System;
    using System.Linq;
    using System.Collections.Generic;
    class P
    {
        class PartGroup
        {
            public List<Part> Parts { get; private set; }
            public PartGroup()
            {
                Parts = new List<Part>();
            }
        }
    
        class Part
        {
        }
    
        class PartCollection
        {
            public List<Part> Parts { get; set; }
            public List<PartGroup> Groups { get; set; }
            public PartCollection()
            {
                Parts = new List<Part>();
                Groups = new List<PartGroup>();
            }
        }
    
        static void Main()
        {
            var groups = new List<PartGroup> { new PartGroup(), new PartGroup(), new PartGroup(), new PartGroup(), new PartGroup() };
            var partColl = new PartCollection();
            partColl.Parts.Add(new Part());
            partColl.Groups.AddRange(groups);
            for (int i = 0; i < 27; i++)
            {
                var part = new Part();
                groups[i % groups.Count].Parts.Add(part);
                partColl.Parts.Add(part);
            }
            partColl.Parts.Add(new Part());
    
            Func<Part, bool> hasGroup = P => partColl.Groups.Any(G => G.Parts.Contains(P));
            var groupless = partColl.Parts.Where(P => !hasGroup(P)).ToList();
        }
    }
