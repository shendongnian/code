    menuStrip1.Renderer = new CustomMenuStripRenderer();
    //
    class CustomMenuStripRenderer : ToolStripSystemRenderer {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
            e.TextFormat &= ~TextFormatFlags.HidePrefix; // Clear the "HidePrefix" bit
            base.OnRenderItemText(e);
        }
    }
