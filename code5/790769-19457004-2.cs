    using System.Reflection;
    public class MyControl : Button {
      private ToolTip toolTip = new ToolTip() {
        UseAnimation = false,
        UseFading = false
      };
      public string ToolTip { get; set; }
      protected override void OnMouseHover(EventArgs e) {
        base.OnMouseHover(e);
        Point mouse = MousePosition;
        mouse.Offset(10, 10);
        MethodInfo m = toolTip.GetType().GetMethod("SetTool",
                               BindingFlags.Instance | BindingFlags.NonPublic);
        m.Invoke(toolTip, new object[] { this, this.ToolTip, 2, mouse });
      }
      protected override void OnMouseLeave(EventArgs e) {
        base.OnMouseLeave(e);
        toolTip.Hide(this);
      }
    }
