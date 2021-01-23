    private void removeDrawing()
    {
        foreach (var ctrl in this.Controls)
        {
            var shapeContainer = ctrl as ShapeContainer;
            if (shapeContainer != null)
            {
                this.Controls.Remove(shapeContainer);
            }
        }
    }
