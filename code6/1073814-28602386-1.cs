    public class PechkinPDFConvertor : IPDFConvertor
    {
        IConverter converter =
                   new ThreadSafeConverter(
                      new RemotingToolset<PdfToolset>(
                           new Win64EmbeddedDeployment(
                               new TempFolderDeployment())));
        public byte[] Convert(string html)
        {
            //            return PechkinSync.Convert(new GlobalConfig(), html);
            return converter.Convert(new HtmlToPdfDocument(html));
        }
    }
