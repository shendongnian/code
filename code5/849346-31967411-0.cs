    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    namespace CodedUIExtensions
    {
        public static class HtmlControlExtensions
        {
            public static bool IsElementVisible(this HtmlControl control)
            {
                // Assume the control is invisible
                bool visible = false;
                System.Drawing.Point p;
                try
                {
                    // If the control is offscreen, bring it into the viewport
                    control.EnsureClickable();
                    // Now check the coordinates of the clickable point
                    visible = control.TryGetClickablePoint(out p)
                        && (p.X > 0 || p.Y > 0);
                }
                catch (Exception ex)
                {
                    // Boom goes the dynamite! Control is not visible.
                    // Log to stdout for debugging.
                    Console.WriteLine(ex);
                }
                return visible;
            }
        }
    }
