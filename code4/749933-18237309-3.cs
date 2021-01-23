    public class Form1 : Form {
       public Form1(){
          InitializeComponent();
          // This contextMenuStrip is used for your Notify Icon
          // Just show it as you do
          contextMenuStrip1.Renderer = new CustomRenderer(){RootToolStrip = contextMenuStrip1};
          //Add your last item first
          int lastItemIndex = contextMenuStrip1.Items.Count - 1;
          contextMenuStrip1.Items[lastItemIndex].AutoSize = false;
          contextMenuStrip1.Items[lastItemIndex].Text = "";
          contextMenuStrip1.Items[lastItemIndex].Height = 40;
       }
    }
    public class CustomRenderer : ToolStripProfessionalRenderer
    {    
       public ToolStrip RootToolStrip;        
       protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
       {
            int i = e.ToolStrip.Items.Count - 1;
            if (e.ToolStrip.Items.IndexOf(e.Item) == i&&e.ToolStrip == RootToolStrip)
            {
               e.Graphics.DrawImage(yourImage, new Rectangle(0,0,e.Item.Width, e.Item.Height));
            } else base.OnRenderMenuItemBackground(e);
       }
    }
