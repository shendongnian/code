    /// <summary>
    /// Gets or sets the type of the drag and drop object required by the Control that the property is set on.
    /// </summary>
    public Type DragDropType { get; set; }
    /// <summary>
    /// Gets or sets the allowable types of objects that can be used in drag and drop operations.
    /// </summary>
    public List<Type> DragDropTypes { get; set; }
    /// <summary>
    /// Gets or sets the ICommand instance that will be executed when the user attempts to drop a dragged item onto a valid drop target Control.
    /// </summary>
    public ICommand DropCommand { get; set; }
    /// <summary>
    /// Gets or sets the DragDropEffects object that specifies the type of the drag and drop operations allowable on the Control that the property is set on.
    /// </summary>
    public DragDropEffects DragDropEffects { get; set; }
    /// <summary>
    /// The Point struct that represents the position on screen that the user initiated the drag and drop procedure.
    /// </summary>
    protected Point DragStartPosition
    {
        get { return dragStartPosition; }
        set { if (dragStartPosition != value) { dragStartPosition = value; } }
    }
    /// <summary>
    /// The UIElement object that represents the UI element that has the attached Adorner control... usually the top level view.
    /// </summary>
    protected UIElement AdornedUIElement
    {
        get { return adornedUIElement; }
        set { if (adornedUIElement != value) { adornedUIElement = value; } }
    }
