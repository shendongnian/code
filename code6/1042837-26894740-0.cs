        protected override void Render(HtmlTextWriter writer)
        {
            //render controls
            //buttonPnl.RenderControl(writer);
            AddAttributesToRender(writer);
            writer.RenderBeginTag(HtmlTextWriterTag.Div); //table start tag
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "5");
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "200");
            writer.RenderBeginTag(HtmlTextWriterTag.Table); //table start tag
            writer.RenderBeginTag(HtmlTextWriterTag.Tr); //row start tag
            writer.RenderBeginTag(HtmlTextWriterTag.Td); // cell start tag
            logoImg.RenderControl(writer); //add logo image
            writer.RenderEndTag(); //cell end tag
            writer.RenderBeginTag(HtmlTextWriterTag.Td); //cell start tag
            errorImg.RenderControl(writer); //add error image
            writer.RenderEndTag(); //cell end tag
            writer.RenderEndTag(); //row end tag
            writer.RenderBeginTag(HtmlTextWriterTag.Tr); //row start tag
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "100%"); //make sure row width is 100% of parent
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, "2"); //make sure row spans 2 cells
            writer.RenderBeginTag(HtmlTextWriterTag.Td); //cell start tag
            mainTextTb.RenderControl(writer); //add main text box
            writer.RenderEndTag(); //cell end tag
            writer.RenderEndTag(); //row end tag
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "right"); //make sure row width is 100% of parent
            writer.RenderBeginTag(HtmlTextWriterTag.Tr); //row start tag
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "100%"); //make sure row width is 100% of parent
            writer.AddAttribute(HtmlTextWriterAttribute.Colspan, "2"); //make sure row spans 2 cells
            writer.RenderBeginTag(HtmlTextWriterTag.Td); //cell start tag
            subTextLbl.RenderControl(writer); //add sub label
            writer.RenderEndTag();//cell end tag
            writer.RenderEndTag(); //row end tag
            writer.RenderEndTag(); //table end tag
            writer.RenderEndTag(); //div end tag
        } 
