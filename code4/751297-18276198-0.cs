     private void RenderBody(HtmlTextWriter writer)
            {
                writer.AddAttribute("class", "mystyle");
                writer.RenderBeginTag("div");
                {
                    writer.AddAttribute("class", "mystyle2");
                    writer.RenderBeginTag("div");
                    {
                        writer.Write("HELLO WORLD");
                    }
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }
