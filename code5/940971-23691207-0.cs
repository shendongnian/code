    public static IList<Item> UnlockWhere(this IEnumerable<Item> list, Expression<Func<Item, bool>> condition) {
        var imagesToUnlock = list.Where(condition);
        foreach (var image in imagesToUnlock)
            image.IsLocked = false;
        return imagesToUnlock.ToList();
    }
