    protected void Page_Load(object sender, System.EventArgs e)
    {
        string fileName = "C:\\Report\\Report_" + System.Guid.NewGuid().ToString() + ".docx";
        using (WordprocessingDocument package = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document))
        {
            this.CreateParts(package);
        }
    }
    private void CreateParts(WordprocessingDocument document)
    {
        ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
        GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);
        /*********************************Code for generating the main Document content *****************************/
        MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
        Document document1 = new Document();
        Body body1 = new Body();
        SectionProperties sectionProperties1 = new SectionProperties() { RsidR = "00350EC0", RsidSect = "0025134C" };
        FooterReference footerReference1 = new FooterReference() { Type = HeaderFooterValues.Default, Id = "rId9" };
        PageSize pageSize1 = new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U };
        PageMargin pageMargin1 = new PageMargin() { Top = 1440, Right = (UInt32Value)1440U, Bottom = 1440, Left = (UInt32Value)1440U, Header = (UInt32Value)708U, Footer = (UInt32Value)708U, Gutter = (UInt32Value)0U };
        Columns columns1 = new Columns() { Space = "708" };
        TitlePage titlePage1 = new TitlePage();
        DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };
        sectionProperties1.Append(footerReference1);
        sectionProperties1.Append(pageSize1);
        sectionProperties1.Append(pageMargin1);
        sectionProperties1.Append(columns1);
        sectionProperties1.Append(titlePage1);
        sectionProperties1.Append(docGrid1);
        document1.Append(body1);
        mainDocumentPart1.Document = document1;
        /*********************************End of Code for generating the main Document content *****************************/
        FooterPart footerPart1 = mainDocumentPart1.AddNewPart<FooterPart>("rId9");
        GenerateFooterPart1Content(footerPart1);
        footerPart1.AddExternalRelationship("http://schemas.openxmlformats.org/officeDocument/2006/relationships/image",
               new System.Uri("<URL to the Image>", System.UriKind.Absolute), "rFTimg"); //rFTimg -> should be same as imageData1'id in GenerateFooterPart1Content
        SetPackageProperties(document);
    }
        private void GenerateFooterPart1Content(FooterPart footerPart1)
        {
            Run run = new Run();
            Picture picture = new Picture();
            Footer footer1 = new Footer();
            Paragraph paragraph85 = new Paragraph() { RsidParagraphAddition = "0025134C", RsidRunAdditionDefault = "00D71D07" };
            ParagraphProperties paragraphProperties85 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId85 = new ParagraphStyleId() { Val = "Footer" };
            paragraphProperties85.Append(paragraphStyleId85);
            paragraph85.Append(paragraphProperties85);
            V.Shape shape1 = new V.Shape() { Id = "_x0000_s7170", Style = "width:456pt;height:31.5pt;mso-position-horizontal-relative:page;mso-position-vertical-relative:page", WrapCoordinates = "-33 0 -33 21086 21600 21086 21600 0 -33 0", Type = "#_x0000_t75" };
            V.ImageData imageData1 = new V.ImageData() { Title = "Word_Footer_Brad_v1", RelationshipId = "rFTimg" };
            shape1.Append(imageData1);
            picture.Append(shape1);
            run.Append(picture);
            paragraph85.Append(run);
            footer1.Append(paragraph85);
            footerPart1.Footer = footer1;
        }
