    interface IPage
    {
        string Name { get; }
        IReadOnlyList<IWidget> Sections { get; }
    }
    
    interface IWidget 
    {
        string Name { get; }
        ITemplate Template { get; set; }
        IReadOnlyList<IWidget> Widgets { get; }
    }
    
    interface ITemplate
    {
        string Name { get; }
        IReadOnlyList<IElement> Elements { get; }
    }
    
    interface IElement
    {
        string Name { get; }
        IList<Assestion> Assetions { get; }
    }
    
    class Assestion
    {
        public AssetionSubject Subject { get; set; }
        public AssetionPredicate Predicate { get; set; }
        public object Value { get; set; }
    }
    
    enum AssetionSubject { InnerText, OuterHtml, etc }
    enum AssetionPredicate { eq, neq, gt, lt, etc }
