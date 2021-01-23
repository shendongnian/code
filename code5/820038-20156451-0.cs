    public static class ExtensionMethods
    {
        public static ICollection<SomeItem> OnlyVisible(this ICollection<SomeItem) items) {
            return items.Where(e => e.isVisible).ToList();
        }
    }
