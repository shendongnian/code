    using System;
    using System.Linq;
    using System.Linq.Expressions;
    namespace MyModels
    {
        using Predicate = Expression<Func<Component, bool>>;
        public partial class Component
        {
            public static Predicate HasKeywordContaining(string keyword)
            {
                return c => c.Keywords.Any(k => k.Value.Contains(keyword));
            }
            public static Predicate IsOwnedBy(string ownerName)
            {
                return c => c.OwnerName.Contains(ownerName);
            }
            public static Predicate HasPartNoContaining(string partNo)
            {
                return c => c.PartNo.Contains(partNo);
            }
        }
    }
