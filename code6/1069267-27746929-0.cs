    namespace MyNamespace
    {
        public class Time : Control
        {
            protected override void Render(HtmlTextWriter writer)
            {
                // no error checking whatsoever! Add that before using!
                writer.Write("<h3>render time: {0}</h3>", 
                             DateTime.Now - (DateTime)Context.Items["loadstarttime"]);
            }
        }
    }
