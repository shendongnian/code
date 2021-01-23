    public class MyRenderer : ToolStripRenderer {
      protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {
        e.ArrowColor = Color.White;
        base.OnRenderArrow(e);
      }
    }
