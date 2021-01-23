    void TrimList(List<string> list)
    {
        int lastNonEmpty = list.FindLastIndex(x => !string.IsNullOrEmpty(x));
        if (lastNonEmpty != list.Count)
        {
            list.RemoveRange(lastNonEmpty + 1, list.Count - lastNonEmpty - 1);
        }
    }
