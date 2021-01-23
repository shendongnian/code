    public static void DoWorkOnPages(IProgramOptions options, Action<DocWrapper, int> actions)
    {
        using (DocWrapper doc = new DocWrapper(options.File))
        {
            foreach (int page in doc.GetPagesToModify(options.Pages).OrderBy(p => p))
            {
                actions(doc, page);
            }
    
            doc.Save(options.OutputFile);
        }
    }
