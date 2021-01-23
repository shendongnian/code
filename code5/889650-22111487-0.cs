    public class LimitedTextStrategy : iTextSharp.text.pdf.parser.ITextExtractionStrategy
        {
    
            public readonly ITextExtractionStrategy textextractionstrategy;
    
            public LimitedTextStrategy(ITextExtractionStrategy strategy)
            {
                this.textextractionstrategy = strategy;
            }
            public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
            {
              foreach (TextRenderInfo info in renderInfo.GetCharacterRenderInfos())
            {
                this.textextractionstrategy.RenderText(info);
            } 
            }
            public string GetResultantText()
            {
                return this.textextractionstrategy.GetResultantText();
            }
    
            public void BeginTextBlock() {
                this.textextractionstrategy.BeginTextBlock();
    
            }
            public void EndTextBlock() {
                this.textextractionstrategy.EndTextBlock();
    
            }
            public void RenderImage(ImageRenderInfo renderInfo) {
                this.textextractionstrategy.RenderImage(renderInfo);
            }
        }
