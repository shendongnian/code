    string chars = "~!@#$%^&*()_+{}:\"<>?";
    foreach (var item in chars.Where(x=> !char.IsLetterOrDigit(x)).GroupBy(x => x))
    {
        Console.WriteLine(string.Format("{0},{1}",item.Key,item.Count()));
    }
