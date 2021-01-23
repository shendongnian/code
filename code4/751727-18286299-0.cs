    //Start Word and create a new document.
	Word._Application oWord;
	Word._Document oDoc;
	oWord = new Word.Application();
	oWord.Visible = true;
	oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,ref oMissing, ref oMissing);
	//Insert a datagridview info into the document.
    DataTable dt = (DataTable)datagridview1.DataSource;
    foreach(DataRow dr in dt.Rows)
    {
	Word.Paragraph oPara1;
	oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
	oPara1.Range.Text = dr[0].ToString();
	oPara1.Range.Font.Bold = 1;
	oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
	oPara1.Range.InsertParagraphAfter();
	 
