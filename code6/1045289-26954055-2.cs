    public static class FlatDataGroupExtensions
    {
        public const string UserType = "User";
        public const string GroupType = "Group";
        public static List<Group> ToGroups(this IEnumerable<FlatDataGroup> elements)
        {
            // Allocate all groups and index by ID.
            var groups = new Dictionary<int, Group>();
            foreach (var element in elements)
            {
                Group group;
                if (!groups.TryGetValue(element.GroupID, out group))
                    groups[element.GroupID] = (group = new Group() { ID = element.GroupID, Name = element.GroupName, ParentGroupID = element.ParentGroupID, Type = GroupType });
                group.Users.Add(new User() { GroupID = element.GroupID, ID = element.UserID, Name = element.UserName, Type = UserType });
            }
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
