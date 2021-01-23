    public class ContextClass
    {
    	public void ContextMethod()
    	{
          this.document.add(new CustomVerticalPositionMark(title, this.tocPlaceholder));
    	}
    }
    class CustomVerticalPositionMark extends VerticalPositionMark
    {
    	final String title;
    	final PlaceHolder tocPlaceholder;
    	CustomVerticalPositionMark(String title, PlaceHolder tocPlaceholder)
    	{
    		this.title = title;
    		this.tocPlaceholder = tocPlaceholder;
    	}
       @Override
       public void draw(final PdfContentByte canvas, final float llx, final float lly, final float urx, final float ury, final float y)
       {
           final PdfTemplate createTemplate = canvas.createTemplate(50, 50);
           tocPlaceholder.put(title, createTemplate);
           canvas.addTemplate(createTemplate, urx - 50, y);
       }
    }
