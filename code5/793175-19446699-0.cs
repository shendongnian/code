    public class DynamicRenderer : IPdfRenderer<PageContent>
    {
        public DynamicRenderer(IPdfRenderer<Paragraph> paragraph
            , IPdfRenderer<Table> table){
            //variable assignment
        }
        public PageContent Render(MigraDoc.DocumentObjectModel.Section s, PageContent baseContent){
            if(baseContent is Paragraph){ return paragraph.Render(s, baseContent as Paragraph); }
            else{ return table.Render(s, baseContent as Table); }
        }
    }
