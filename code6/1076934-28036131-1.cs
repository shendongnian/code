    public static class UIItemExtensions
    {
        public static IEnumerable<UIItemBase> WalkItems(this UIItemBase item)
        {
            if (item == null)
                yield break;
            yield return item;
            foreach (var child in item.Items)
                foreach (var subChild in child.WalkItems())
                    yield return subChild;
        }
    }
