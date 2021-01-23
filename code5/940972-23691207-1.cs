    public static IList<Item> UnlockWhere(this IEnumerable<Item> list, Func<Item, bool> condition) {
        var imagesToUnlock = list.Where(condition).ToList();
        foreach (var image in imagesToUnlock)
            image.IsLocked = false;
        return imagesToUnlock;
    }
