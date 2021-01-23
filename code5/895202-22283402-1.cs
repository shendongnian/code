    using System;
    using System.Globalization;
    public class Program {
        private static void Main(string[] args) {
            var wordDocParagraphReader = new WordDocParagraphReader(@"E:\someDoc.docx");
            Console.WriteLine(wordDocParagraphReader.GetParagraph(0));
            Console.ReadLine();
            wordDocParagraphReader.Docs.Close();
            wordDocParagraphReader.Word.Quit();
        }
    }
    public class WordDocParagraphReader {
        public int ParagraphsCount { get; private set; }
        public Microsoft.Office.Interop.Word.Document Docs { get; private set; }
        public Microsoft.Office.Interop.Word.Application Word { get; private set; }
        public WordDocParagraphReader(object @path) {
            Word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object readOnly = true;
            Docs = Word.Documents.Open(ref path,
                                       ref miss,
                                       ref readOnly,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss,
                                       ref miss);
            ParagraphsCount = Docs.Paragraphs.Count;
        }
        public string GetParagraph(int paragraphNumber) {
            if (paragraphNumber + 1 <= ParagraphsCount || paragraphNumber < 0) {
                return Docs.Paragraphs[paragraphNumber + 1].Range.Text.ToString(CultureInfo.InvariantCulture);
            }
            Console.WriteLine(String.Format("invalid paragraph requests {0} \n( the total paragraphs in file is {1})",
                                            paragraphNumber,
                                            ParagraphsCount));
            return string.Empty;
        }
    }
