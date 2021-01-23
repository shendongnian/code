    void TrimList(List<string> list)
    {
        int lastNonEmpty = list.FindLastIndex(x => !string.IsNullOrEmpty(x));
        if (lastNonEmpty != -1)
        {
            list.RemoveRange(lastNonEmpty, list.Count - lastNonEmpty);
        }
    }
