    public static class MyLinqExpressions {
        public static System.Linq.Expressions.Expression<Func<Group,GroupModel>>
            fSelect = g => new GroupModel {
                Name = g.Name,
                Description = g.Description,
                ID = g.ID
            };
    }
