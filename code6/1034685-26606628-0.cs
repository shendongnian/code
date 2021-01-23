    public class WhiteArrowRenderer : ToolStripProfessionalRenderer { 
        protected override void OnRenderArrow (ToolStripArrowRenderEventArgs e) { 
            var tsMenuItem = e.Item as ToolStripMenuItem;
            if (tsMenuItem != null)
                e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }
    }
