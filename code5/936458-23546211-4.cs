    using System.Web.UI.HtmlControls;  
      
    HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "name");
            span.InnerText = "Cardiology";
            //make more spans
    
            HtmlAnchor a = new HtmlAnchor();
            a.HRef = "test.htm";
            a.Attributes.Add("class", "premote trait-link large btn");
            a.Attributes.Add("data-trait-id", "9");
    
            HtmlGenericControl li = new HtmlGenericControl("li");
            //add attributes
    
            a.Controls.Add(span);
            li.Controls.Add(a);
    
            ulSpecialty_selector.Controls.Add(li);
