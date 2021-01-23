    foreach (var s in searchterm.Split(' '))
    {
      if (!Lucene.Net.Analysis.Standard.StandardAnalyzer.STOP_WORDS_SET.Contains(s))
      {
         completeQuery.Add(new Term("title", s));
      }
    }
