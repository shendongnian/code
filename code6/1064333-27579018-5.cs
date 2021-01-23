    public class WrappedTextBox : System.Web.UI.WebControls.TextBox
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div id=\"div{0}\" runat=\"server\">", this.ID.Replace("txt", String.Empty));
            base.Render(writer);
            writer.WriteEndTag("div");
        }
    }
