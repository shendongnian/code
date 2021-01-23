    public static class MyLinqExpressions {
        public static Func<Group,GroupModel>
            fSelect = g => new GroupModel {
                Name = g.Name,
                Description = g.Description,
                ID = g.ID
            };
    }
