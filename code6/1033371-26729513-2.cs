    using Microsoft.Office.Interop.Word;
    using System.IO;
        
    private void btnCreateQuotation_Click(object sender, EventArgs e)
    {
        var spareList = new List<Spare>();
        spareList.Add(new Spare{ SparePicture  = ImageToByteArray(Image.FromFile(@"C:\temp\11.png"))});
        spareList.Add(new Spare { SparePicture = ImageToByteArray(Image.FromFile(@"C:\temp\1.png")) });
        CreateDocument(@"C:\Temp\MyWordDoc.docx", spareList);
    }
    
    public void CreateDocument(string docFilePath, List<Spare> lstOrderedSpares)
    {
        Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
        Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Add(); //If you're creating a document
        //Microsoft.Office.Interop.Word._Document oDoc = oWord.Documents.Open(docFilePath, ReadOnly: false, Visible: true); //If you're opening a document
    
        //To see whats going on while populating the word document set Visible = true
        oWord.Visible = true;
    
        //Insert text
        Object oMissing = System.Reflection.Missing.Value;
        var oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
        oPara1.Range.Text = "First Text";
        oPara1.Range.InsertParagraphAfter();
    
        //Here is the trick to insert a picture from a byte array into MS Word you need to 
        //convert the ByteArray into an Image and using the Clipboard paste it into the document
        Image sparePicture = ByteArrayToImage(lstOrderedSpares[0].SparePicture);
        Clipboard.SetDataObject(sparePicture);
        var oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
        oPara2.Range.Paste();
        oPara2.Range.InsertParagraphAfter();
    
        //Insert some more text
        var oPara3 = oDoc.Content.Paragraphs.Add(ref oMissing);
        oPara3.Range.Text = "Second Text" + Environment.NewLine;
        oPara3.Range.InsertParagraphAfter();
    
        sparePicture = ByteArrayToImage(lstOrderedSpares[1].SparePicture);
        Clipboard.SetDataObject(sparePicture);
        var oPara4 = oDoc.Content.Paragraphs.Add(ref oMissing);
        oPara4.Range.Paste();
        oPara4.Range.InsertParagraphAfter();
    
        oDoc.SaveAs(docFilePath); //If you're creating a document
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
    //Method I use to test loading images from disk into byte[]'s and inserting them into word
    public byte[] ImageToByteArray(System.Drawing.Image imageIn)
    {
        byte[] result = null;
        using (MemoryStream ms = new MemoryStream())
        {
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            result = ms.ToArray();
        }
        return result;
    }
