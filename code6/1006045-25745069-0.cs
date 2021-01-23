    public static void AddContentToTemplateCopy(string templateDocumentPath, 
                                                string contentDocumentPath, 
                                                List<Source> sources, 
                                                string outName)
        {
            sources = new List<Source>()
            {
                new Source(new WmlDocument(contentDocumentPath),false),
                new Source(new WmlDocument(templateDocumentPath),true),
            };
            DocumentBuilder.BuildDocument(sources, outName);
        }
