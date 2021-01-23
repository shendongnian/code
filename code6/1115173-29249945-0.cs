    object oMissing = System.Reflection.Missing.Value;
	object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */ 
	//Start Word and create a new document.
	Word._Application oWord;
	Word._Document oDoc;
	oWord = new Word.Application();
