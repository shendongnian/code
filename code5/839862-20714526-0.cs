    // SFML.Graphics.Shape
    public Color FillColor
    {
        get
        {
            return Shape.sfShape_getFillColor(base.CPointer);
        }
        set
        {
             Shape.sfShape_setFillColor(base.CPointer, value);
        }
    }
