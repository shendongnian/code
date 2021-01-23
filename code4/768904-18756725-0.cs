	using Word = Microsoft.Office.Interop.Word;
	using Alias = Microsoft.Office.Interop.Word;
	public Test()
	{
		var doc = new Alias.Document();
		var doc2 = new Alias.Document();
		var t = this.CloneModel(ref doc, ref doc2);
	}
	private bool CloneModel(ref Alias.Document objTargetDocument, ref Alias.Document objSourceDocument)
	{
		var missing = Type.Missing;
		Word.Shape objShape;
		objShape = objTargetDocument.Shapes.AddTextbox(
			Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationUpward, 0, 0, 0, 0, ref missing); <== note the missing here instead of objRange
		objShape.Name = "Carma DocSys~Brief"; // no longer throwing exceptions (hard coded string)
		objShape.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
		return true;
	} 
