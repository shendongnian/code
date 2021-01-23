        public class CustomToolStripRenderer : ToolStripProfessionalRenderer {
            public CustomToolStripRenderer() : base(new MyColorTable()) {
                this.RoundEdges = true;
            }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e) {
                // etc..
            }
        } 
