    class Program
    {
        static void Main(string[] args)
        {
            var groups = new List<Group>();
            var items = groups
                .SelectMany(group => group.SubGroups, (group, subGroup) => new
                    {
                        group,
                        subGroup
                    })
                .SelectMany(anon => anon.subGroup.Items, (anon, item) => new
                    {
                        Group = anon.group,
                        SubGroup = anon.subGroup,
                        Item = item
                    });
            Console.Read();
        }
    }
    class Group
    {
        public string GroupName { get; set; }
        public List<SubGroup> SubGroups { get; set; }
    }
    class SubGroup
    {
        public string SubGroupName { get; set; }
        public List<Item> Items { get; set; }
    }
    class Item
    {
        public string ItemName { get; set; }
    }
