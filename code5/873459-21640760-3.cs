    protected override void Render(HtmlTextWriter writer)
    {
        writer.AddAttribute(HtmlTextWriterAttribute.Class, "modalbox");
        if (!ClientVisible) {
            writer.AddAttribute(HtmlTextWriterAttribute.Style, "display: none");
        }
        writer.RenderBeginTag(HtmlTextWriterTag.Div); // div1
        writer.AddAttribute(HtmlTextWriterAttribute.Class, "modalbox-m1");
        writer.RenderBeginTag(HtmlTextWriterTag.Div); // div2
        writer.AddAttribute(HtmlTextWriterAttribute.Class, "modalbox-m2");
        writer.RenderBeginTag(HtmlTextWriterTag.Div); // div3
        // Render children.
        // None of the control collections are altered in this process.
        // (This may render other content if sub-classing an
        //  existing control; in that case, loop and render the
        //  the children individually, if such is appropriate.)
        base.Render(writer);
        writer.RenderEndTag(); // div3   
        writer.RenderEndTag(); // div2
        writer.RenderEndTag(); // div1
    }
