    using System.Linq;
    ...
    private void removeDrawing()
    {
        foreach (var ctrl in this.Controls.OfType<ShapeContainer>().ToList())
        {
            this.Controls.Remove(ctrl);
        }
    }
