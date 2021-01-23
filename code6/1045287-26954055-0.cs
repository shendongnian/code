    public static class FlatDataGroupExtensions
    {
        public const string UserType = "User";
        public const string GroupType = "Group";
        public static List<Group> ToGroups(this IEnumerable<FlatDataGroup> elements)
        {
            // Allocate all groups and index by ID.
            var groups = elements
                .GroupBy(fg => fg.GroupID)
                .Select(grouping =>
                    {
                        var first = grouping.First();
                        Group group = new Group() { ID = grouping.Key, Name = first.GroupName, ParentGroupID = first.ParentGroupID, Type = GroupType };
                        group.Users.AddRange(grouping.Select(u => new User() { GroupID = grouping.Key, ID = u.UserID, Name = u.UserName, Type = UserType }));
                        return group;
                    })
                .ToDictionary(g => g.ID);
            // Attach child groups to their parents.
            foreach (var group in groups.Values)
            {
                Group parent;
                if (groups.TryGetValue(group.ParentGroupID, out parent) && parent != group) // Second check for safety.
                    parent.Groups.Add(group);
            }
            // Return only root groups, sorted by ID.
            return groups.Values.Where(g => !groups.ContainsKey(g.ParentGroupID)).OrderBy(g => g.ID).ToList();
        }
    }
