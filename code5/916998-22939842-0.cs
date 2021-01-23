    public class TestPanel : DockPanel
    {
        protected override Size MeasureOverride(Size constraint)
        {
            System.Console.WriteLine("MeasureOverride called for " + this.Name + ".");
            return base.MeasureOverride(constraint);
        }
    protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
    {
        System.Console.WriteLine("ArrangeOverride called for " + this.Name + ".");
        return base.ArrangeOverride(arrangeSize);
    }
    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        System.Console.WriteLine("OnRender called for " + this.Name + ".");
        base.OnRender(dc);
    }
    }
