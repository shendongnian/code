    [ToolboxItemAttribute(false)]
    public class ContentQuery : ContentByQueryWebPart
    {
        public MainXslTemplateEnum MainXslTemplate { get; set; }
        public override ToolPart[] GetToolParts()
        {
            List<ToolPart> toolParts = new List<ToolPart>();
            toolParts.Add(new ContentQueryToolPart());
            toolParts.AddRange(base.GetToolParts());
            return toolParts.ToArray();
        }
    }
