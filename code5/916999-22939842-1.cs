    public class TestPanel : DockPanel
    {
        Size? arrangeResult;
    protected override Size MeasureOverride(Size constraint)
    {
        arrangeResult = null;
        System.Console.WriteLine("MeasureOverride called for " + this.Name + ".");
        return base.MeasureOverride(constraint);
    }
    protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
    {
        if(!arrangeResult.HasValue)
        {
            System.Console.WriteLine("ArrangeOverride called for " + this.Name + ".");
            // Do your arrange work here
            arrangeResult = base.ArrangeOverride(arrangeSize);
        }
        return arrangeResult.Value;
    }
    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        System.Console.WriteLine("OnRender called for " + this.Name + ".");
        base.OnRender(dc);
    }
    }
