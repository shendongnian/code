    var originalContent = Content as FrameworkElement;
    //Reference Type: originalContent POINTS AT Content;
    var grid = new Grid();
    Content = grid;
    //Reference Type: Content POINTS AT grid vsv. originalContent now POINTS AT grid
    // Now because of Pointers and Reference Types
    // originalContent = grid
