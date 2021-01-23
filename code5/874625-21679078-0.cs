    public static class ContentControlExtensions
    {
        public static IEnumerable<OpenXmlElement> ContentControls(
            this OpenXmlPart part)
        {
            return part.RootElement
                .Descendants()
                .Where(e => e is SdtBlock || e is SdtRun);
        }
    
        public static IEnumerable<OpenXmlElement> ContentControls(
            this WordprocessingDocument doc)
        {
            foreach (var cc in doc.MainDocumentPart.ContentControls())
                yield return cc;
        }
    }
