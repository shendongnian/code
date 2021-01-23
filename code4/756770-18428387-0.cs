        public static IEnumerable<Group> EarnedGroups(this IEnumerable<Group> data)
        {
            foreach (var group in data)
            {
                var items = group.ChildItems.Where(x => x.Earned).ToList();
                var groups = group.ChildGroups.EarnedGroups().ToList();
                if (items.Count > 0 || groups.Count > 0 || group.Earned)
                    yield return new
                            Group
                            {
                                ID = group.ID,
                                Available = group.Available,
                                Earned = group.Earned,
                                ChildItems = items,
                                ChildGroups = groups
                           };
            }
        }
