    bool AnyDifferent(string file1Path, string file2Path)
    {
        using (var file1Enumerator = File.ReadLines(file1Path).GetEnumerator())
        using (var file2Enumerator = File.ReadLines(file2Path).GetEnumerator())
        {
            while (true)
            {
                bool result1 = file1Enumerator.MoveNext();
                bool result2 = file2Enumerator.MoveNext();
                if (result1 != result2)
                    return true;
                else if (!result1 && !result2)
                    return false;
                var file1LineSplit = file1Enumerator.Current.Split('|');
                var file2LineSplit = file2Enumerator.Current.Split('|');
                if (!file1LineSplit.Take(2).SequenceEqual(file2LineSplit.Take(2)))
                   return true;
            }
        }
    }
