    private List<PPShape> _shapesEntered = new List<PPShape>();       
    private List<PPShape> _shapesOnSlide = new List<PPShape>();
    void m_MouseHookManager_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        // Temporary list holding active shapes (shapes with the mouse cursor within the shape)
        List<PPShape> activeShapes = new List<PPShape>();       
            
        // Loop through all shapes on the slide, and add active shapes to the list
        foreach (PPShapes in _shapesOnSlide)
        {
            if (MouseWithinShape(s, e))
            {
                activeShapes.Add(s);
            }
        }
        // Handle shape MouseEnter events
        // Select elements that are active but not currently in the shapesEntered list
        foreach (PPShape s in activeShapes)
        {
            if (!_shapesEntered.Contains(s))
            {
                // Raise your custom MouseEntered event
                s.OnMouseEntered();
                // Add the shape to the shapesEntered list
                _shapesEntered.Add(s);
            }
        }
        // Handle shape MouseLeave events
        // Remove elements that are in the shapes entered list, but no longer active
        HashSet<long> activeIds = new HashSet<long>(activeShapes.Select(s => s.Id));
        _shapesEntered.RemoveAll(s => {
            if (!activeIds.Contains(s.Id)) {
                // The mouse is no longer over the shape
                // Raise your custom MouseLeave event
                s.OnMouseLeave();
                // Remove the shape
                return true;
            }
            else
            {
                return false;
            }
        });
    }
