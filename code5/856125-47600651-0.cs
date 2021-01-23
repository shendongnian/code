    public override void DrawText(CGRect rect)
    {
         rect.X = 5; // or whatever padding settings you want
         base.DrawText(AlignmentRectInsets.InsetRect(rect));
    }
