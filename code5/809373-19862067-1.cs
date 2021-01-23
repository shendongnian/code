    public class CustomRenderer : ToolStripProfessionalRenderer
    {
        int innerImagePadding = 2;
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
            Image img = e.Item.Tag as Image;
            if(img == null) base.OnRenderItemText(e);
            else {
              e.Graphics.DrawImage(img, e.Item.ContentRectangle.Left + e.Item.Bounds.Height + innerImagePadding,
                                   e.Item.ContentRectangle.Top + innerImagePadding, 
                                   Math.Max(1, e.Item.ContentRectangle.Height - innerImagePadding*2), 
                                   Math.Max(1, e.Item.ContentRectangle.Height - innerImagePadding*2));              
              Rectangle textRect = new Rectangle(e.Item.ContentRectangle.Left + e.Item.Bounds.Height*2, 
                                   e.Item.ContentRectangle.Top +1, 
                                   e.TextRectangle.Width, 
                                   e.TextRectangle.Height);
              e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(e.TextColor), textRect);
           }
        }
    }
    //Usage
    ContextMenuStrip cm = new ContextMenuStrip();
    cm.Items.Add(new ToolStripMenuItem("Clear all", myImage) {Tag = myImage});
    cm.Items.Add(new ToolStripMenuItem("Remove all", myImage){Tag = myImage});
    this.ContextMenuStrip = cm; //set the ContextMenuStrip for the form
    //set the custom Renderer
    cm.Renderer = new CustomRenderer();
