    public static class FileProcessorFactory 
    {
        public static IFileProcessor Create(string extension) {
            switch (extension) {
                case "pdf":
                    return new PdfFileProcessor();
                case "html":
                    return new HtmlFileProcessor();
                // etc...
            }
        }
    }
