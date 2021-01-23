    using Microsoft.Office.Interop.Word;
    using System.IO;
    
    private void btnCreateQuotation_Click(object sender, EventArgs e)
    {
        CreateDocument(@"C:\Temp\MyWordDoc.docx", new List<Spare>());
    }
    
    public void CreateDocument(string docFilePath, List<Spare> lstOrderedSpares)
    {
    
        Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
        Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add();  //If you're creating a document
        //Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Open(docFilePath, ReadOnly: false, Visible: true); //If you're opening a document
                
        oWord.Visible = true;
                            
        //Insert text
        Range rng = oDoc.Range();
        rng.Text = "New Text";
        oWord.Selection.EndKey();
        oWord.Selection.TypeParagraph();
                
        ////Insert a picture from a file path 
        //Range rngPicFromFile = oDoc.Range(endOfContent);
        //oDoc.Shapes.AddPicture(@"C:\Temp\Blue hills.jpg", Type.Missing, Type.Missing, rngPicFromFile);
        //oWord.Selection.EndKey();
        //oWord.Selection.TypeParagraph();
    
        //To insert a picture from a byte array you need to use the Clipboard to paste it in
        object endOfContent = oDoc.Content.End - 1; 
        Range rngPic = oDoc.Range(endOfContent);
        //Here is the trick to convert the ByteArray into an image and paste it in the document
        Image sparePicture = ByteArrayToImage(lstOrderedSpares[0].SparePicture);
        Clipboard.SetDataObject(sparePicture);
        rngPic.Paste();
    
        oDoc.SaveAs(docFilePath);  //If you're creating a document
        //oDoc.Save();  //If you're opening a document
        oDoc.Close();
        oWord.Quit();
    }
    
    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
        MemoryStream ms = new MemoryStream(byteArrayIn);
        Image returnImage = Image.FromStream(ms);
        return returnImage;
    }
