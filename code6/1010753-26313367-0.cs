    using System;
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.QueryParsers;
    using Lucene.Net.Search;
    using Lucene.Net.Store;
    
    namespace TestProgram
    {
      class Program
      {
        static void Main(string[] args)
        {
          FSDirectory directory = FSDirectory.Open(@"c:\temp\myindex");
    
          BuildIndex(directory);
          QueryIndex(directory);
        }
    
        static void BuildIndex(Directory directory)
        {
          string[] paths = new[]
          {
            @"C:\Users\vj\folder1\lucene\",
            @"C:\Users\vj\folder1\lucene\folder1\folder2",
            @"C:\Users\vj\folder2\lucene2\folder1\lucene\"
          };
    
          Analyzer analyzer = new WhitespaceAnalyzer();
          
          using (var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED))
          {
            foreach (string path in paths)
            {
              Document doc = new Document();
              var field = new Field("Path", path, Field.Store.YES, Field.Index.NOT_ANALYZED);
              doc.Add(field);
    
              writer.AddDocument(doc);
            }
          }
        }
    
        private static void QueryIndex(Directory directory)
        {
          string userQueryString = @"folder1\lucene\";
    
          Analyzer analyzer = new WhitespaceAnalyzer();
          var queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, "Path", analyzer);
          queryParser.AllowLeadingWildcard = true;
    
          string queryString = "*" + userQueryString.Replace(@"\", @"\\");
    
          var query = queryParser.Parse(queryString);
    
          IndexSearcher searcher = new IndexSearcher(directory);
          IndexReader reader = searcher.IndexReader;
          TopDocs topDocs = searcher.Search(query, 100);
    
          foreach (ScoreDoc doc in topDocs.ScoreDocs)
          {
            string path = reader.Document(doc.Doc).Get("Path");
            Console.WriteLine(path);
          }
          Console.ReadKey();
        }
      }
    }
