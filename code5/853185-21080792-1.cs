    using System.Linq;
    ...
    private void removeDrawing()
    {
        foreach (var ctrl in this.Controls.OfType<ShapeContainer>())
        {
            this.Controls.Remove(ctrl);
        }
    }
