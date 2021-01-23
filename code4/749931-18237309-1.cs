    public class Form1 : Form {
       public Form1(){
          InitializeComponent();
          // This contextMenuStrip is used for your Notify Icon
          // Just show it as you do
          contextMenuStrip1.Renderer = new CustomRenderer();
       }
    }
    public class CustomRenderer : ToolStripProfessionalRenderer
    {            
       protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
       {
          e.Graphics.DrawImage(yourImage, e.AffectedBounds);
       }
    }
