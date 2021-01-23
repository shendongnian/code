    public class CustomTreeView : TreeView
    {
        protected override void Render( HtmlTextWriter writer )
        {
            StringBuilder sb = new StringBuilder();
            using ( StringWriter sw = new StringWriter( sb ) )
            using ( HtmlTextWriter tw = new HtmlTextWriter( sw ) )
            {
                base.Render( tw );
                sw.Flush();
                sb.Replace( "alt=\"\"", "" );
                writer.Write( sb.ToString() );
            }
        }
    }
