    public void AddDataSheets(PdfCopy copy) {
        IEnumerable<Movie> movies = PojoFactory.GetMovies();
        // Loop over all the movies and fill out the data sheet
        foreach (Movie movie in movies) {
            PdfReader reader = new PdfReader(DATASHEET_PATH);
            using (var ms = new MemoryStream()) {
                using (PdfStamper stamper = new PdfStamper(reader, ms)) {
                Fill(stamper.AcroFields, movie);
                stamper.FormFlattening = true;
            }
            reader = new PdfReader(ms.ToArray());
            copy.AddPage(copy.GetImportedPage(reader, 1));
        }
    }
