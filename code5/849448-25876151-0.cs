    PowerPoint.SlideShowWindow	ppWindow;
    PowerPoint.Slide			slide		= ppWindow.View.Slide;
    if (slide.HasNotesPage == MsoTriState.msoTrue) {
	    PowerPoint.SlideRange notesPages = slide.NotesPage;
        foreach (PowerPoint.Shape shape in notesPages.Shapes) {
            if (shape.Type == MsoShapeType.msoPlaceholder) {
                if (shape.PlaceholderFormat.Type == PowerPoint.PpPlaceholderType.ppPlaceholderBody) {
                    Debug.WriteLine("Slide[" + slide.SlideIndex + "] Notes: [" + shape.TextFrame.TextRange.Text + "]");				
                }
            }
        }
    }
    
