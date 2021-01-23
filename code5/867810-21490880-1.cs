    // ...
    var sectionProperties = body.GetFirstChild<SectionProperties>();
    // pageSize contains Width and Height properties
    var pageSize = sectionProperties.GetFirstChild<PageSize>();
    
    // this contains information about surrounding margins
    var pageMargin = sectionProperties.GetFirstChild<PageMargin>();
    // this contains information about spacing between neighbouring columns of text
    // this can be useful if You use page layout with multiple text columns
    var columns = sectionProperties.GetFirstChild<Columns>();
    var spaceBetweenColumns = columns.Space.Value;
    var columnsCount = columns.ColumnCount.Value;
    
