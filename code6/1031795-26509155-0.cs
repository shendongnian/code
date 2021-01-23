    internal class NoHighlightRenderer : ToolStripProfessionalRenderer {
      protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
        if (e.Item.OwnerItem == null) {
          base.OnRenderMenuItemBackground(e);
        }
      }
    }
