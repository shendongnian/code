     var span = new HtmlGenericControl("span");
     span.InnerHtml = "Hello ";
     span.Attributes["id"] = "span";
     span.ID = "span";
     String myTesxt = @"This is some " + span.InnerHtml + " text";
     myDiv.InnerHtml = myTesxt;
     span.InnerHtml = "";
    
     myDiv.Controls.Add(span);
     var a=myDiv.FindControl("span");
