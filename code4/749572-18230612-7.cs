    IEnumerable<SelectListItem> GetAllEnumValues<T>()
    {
        // In truth, the array returned by Enum.GetValues **is** strongly typed
        // but is "downcasted" to Array. So we re-upcast it.
        T[] values = (T[])Enum.GetValues(typeof(T));
        ...
            Value = EnumToString<T>.Do(selectedItem),
            // or
            Value = EnumToObject<T>.Do(selectedItem).ToString(),
    }
