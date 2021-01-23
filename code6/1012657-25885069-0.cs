	void DrawText(XGraphics gfx, int number)
	{
		BeginBox(gfx, number, "Text Styles");
		 
		const string facename = "Times New Roman";
		//XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
		XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.WinAnsi, PdfFontEmbedding.Default);
		XFont fontRegular = new XFont(facename, 20, XFontStyle.Regular, options);
		XFont fontBold = new XFont(facename, 20, XFontStyle.Bold, options);
		XFont fontItalic = new XFont(facename, 20, XFontStyle.Italic, options);
		XFont fontBoldItalic = new XFont(facename, 20, XFontStyle.BoldItalic, options);
		// The default alignment is baseline left (that differs from GDI+)
		gfx.DrawString("Times (regular)", fontRegular, XBrushes.DarkSlateGray, 0, 30);
		gfx.DrawString("Times (bold)", fontBold, XBrushes.DarkSlateGray, 0, 65);
		gfx.DrawString("Times (italic)", fontItalic, XBrushes.DarkSlateGray, 0, 100);
		gfx.DrawString("Times (bold italic)", fontBoldItalic, XBrushes.DarkSlateGray, 0, 135);
		EndBox(gfx);
	}
