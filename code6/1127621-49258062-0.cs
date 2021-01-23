    using System.Web.UI;
    public class MyGridView
       : System.Web.UI.WebControls.GridView
    {
       public MyGridView()
       {
       }
   
       public override void RenderControl(HtmlTextWriter writer)
       {
          /* The underlying GridView class renders a DIV as a container in
             RenderControl(), so we can add attributes here, such as a class
             to hide it.
          */
          writer.AddAttribute(HtmlTextWriterAttribute.Class, "hidden");
          base.RenderControl(writer);
       }
   
       protected override void RenderContents(HtmlTextWriter writer)
       {
          /* We don't want the underlying GridView's container DIV to actually
             wrap the internal TABLE, so calling RenderEndTag() here will cause
             it to be closed before the TABLE is rendered (which happens in
             RenderChildren())...
          */
          writer.RenderEndTag();
   
          base.RenderContents(writer);
   
          /* ...However, when this function exits, RenderControl() will call
             RenderEndTag() itself to close what is expected to be the container
             DIV, so we need to provide a open tag for it.  We'll use a SPAN as
             that will have the least effect on the HTML and we could, of
             course, add any required attributes to style it, etc, if required.
          */
          writer.RenderBeginTag(HtmlTextWriterTag.Span);
       }
   
       /* If you need to add any additional attributes to the TABLE tag, you
          can do that here with a call to writer.AddAttribute(); if not, this
          override is redundant.
       protected override void RenderChildren(HtmlTextWriter writer)
       {
          // TODO: call writer.AddAttribute() if required
          base.RenderChildren(writer);
       }
       */
    }
