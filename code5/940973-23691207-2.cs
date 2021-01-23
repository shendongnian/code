    public static IEnumerable<Item> UnlockWhere(this IEnumerable<Item> list, Func<Item, bool> condition) {
        foreach (var image in list)
            if (condition(image)) {
                image.IsLocked = false;
                yield return image;
            }
    }
