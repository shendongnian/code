    void TrimList(List<string> list)
    {
        int lastNonEmpty = list.FindLastIndex(x => !string.IsNullOrEmpty(x));
        int firstToRemove = lastNonEmpty + 1;
        list.RemoveRange(firstToRemove, list.Count - firstToRemove);
    }
