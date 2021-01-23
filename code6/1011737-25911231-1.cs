    var childLowest = new TemplateDataQueryElement
    {
        Query = "Lowest"
    };
    var childMiddle = new TemplateDataQueryElement
    {
        Query = "Middle",
        Children = new List<TemplateDataQueryElement>
        {
            childLowest
        }
    };
    childLowest.Parent = childMiddle;
    var parent = new TemplateDataQueryElement
    {
        Query = "Parent",
        Children = new List<TemplateDataQueryElement>
        {
            childMiddle
        }
    };
    childMiddle.Parent = parent;
