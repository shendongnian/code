    /**
     * Step 1 - Variable Setup
     */
    //This is the folder that we'll be basing all other directory paths on
    var workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //This folder will hold our PDFs with text that we're searching for
    var folderPathContainingPdfsToSearch = Path.Combine(workingFolder, "Pdfs");
    var folderPathContainingPdfsCombined = Path.Combine(workingFolder, "Pdfs Combined");
    //Create our directories if they don't already exist
    System.IO.Directory.CreateDirectory(folderPathContainingPdfsToSearch);
    System.IO.Directory.CreateDirectory(folderPathContainingPdfsCombined);
    var searchText1 = "ABC";
    var searchText2 = "DEF";
    /**
     * Step 2 - Create sample PDFs
     */
    //Create 100 sample PDFs
    for (var i = 0; i < 100; i++) {
        using (var fs = new FileStream(Path.Combine(folderPathContainingPdfsToSearch, i.ToString() + ".pdf"), FileMode.Create, FileAccess.Write, FileShare.None)) {
            using (var doc = new Document()) {
                using (var writer = PdfWriter.GetInstance(doc, fs)) {
                    doc.Open();
                    //Add a title so we know what page we're on when we combine
                    doc.Add(new Paragraph(String.Format("This is page {0}", i)));
                    //Add various strings every once in a while.
                    //(Yes, I know this isn't evenly distributed but I haven't
                    // had enough coffee yet.)
                    if (i % 10 == 3) {
                        doc.Add(new Paragraph(searchText1));
                    } else if (i % 10 == 6) {
                        doc.Add(new Paragraph(searchText2));
                    } else if (i % 10 == 9) {
                        doc.Add(new Paragraph(searchText1 + searchText2));
                    } else {
                        doc.Add(new Paragraph("Blah blah blah"));
                    }
                    doc.Close();
                }
            }
        }
    }
    /**
     * Step 3 - Search and merge
     */
    //We'll search for two different strings just to add some spice
    var reg = new Regex("(" + searchText1 + "|" + searchText2 + ")");
    //Loop through each file in the directory
    foreach (var filePath in Directory.EnumerateFiles(folderPathContainingPdfsToSearch, "*.pdf")) {
        using (var pdfReader = new PdfReader(filePath)) {
            for (var page = 1; page <= pdfReader.NumberOfPages; page++) {
                //Get the text from the page
                var currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, new SimpleTextExtractionStrategy());
                currentText.IndexOf( "",  StringComparison.InvariantCultureIgnoreCase )
                
                //DO NOT DO THIS EVER!! See this for why https://stackoverflow.com/a/10191879/231316
                //currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                //Match our pattern against the extracted text
                var matches = reg.Matches(currentText);
                //Bail early if we can
                if (matches.Count == 0) {
                    continue;
                }
                //Loop through each match
                foreach (var m in matches) {
                    //This is the file path that we want to target
                    var destFile = Path.Combine(folderPathContainingPdfsCombined, m.ToString() + ".pdf");
                    //If the file doesn't already exist then just copy the file and move on
                    if (!File.Exists(destFile)) {
                        System.IO.File.Copy(filePath, destFile);
                        continue;
                    }
                    //The file exists so we're going to "append" the page
                    //However, writing to the end of file in Append mode doesn't work,
                    //that would be like "add a file to a zip" by concatenating two
                    //two files. In this case, we're actually creating a brand new file
                    //that "happens" to contain the original file and the matched file.
                    //Instead of writing to disk for this new file we're going to keep it
                    //in memory, delete the original file and write our new file
                    //back onto the old file
                    using (var ms = new MemoryStream()) {
                        //Use a wrapper helper provided by iText
                        var cc = new PdfConcatenate(ms);
                        //Open for writing
                        cc.Open();
                        //Import the existing file
                        using (var subReader = new PdfReader(destFile)) {
                            cc.AddPages(subReader);
                        }
                        //Import the matched file
                        //The OP stated a guarantee of only 1 page so we don't
                        //have to mess around with specify which page to import.
                        //Also, PdfConcatenate closes the supplied PdfReader so
                        //just use the variable pdfReader.
                        using (var subReader = new PdfReader(filePath)) {
                            cc.AddPages(subReader);
                        }
                        //Close for writing
                        cc.Close();
                        //Erase our exisiting file
                        File.Delete(destFile);
                        //Write our new file
                        File.WriteAllBytes(destFile, ms.ToArray());
                    }
                }
            }
        }
    }
