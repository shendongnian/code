    var index = 0;
    
          var htmlDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
          htmlDiv.Attributes.Add("id", string.Format("_myDiv{0}", index));
          htmlDiv.Attributes.Add("class", "CommContent");
    
          var editComm = new System.Web.UI.HtmlControls.HtmlAnchor();
          var image = new System.Web.UI.HtmlControls.HtmlImage { Src = "../../../images/edit_property.png" };
          editComm.Controls.Add(image);
    
          editComm.Attributes.Add("onclick", string.Format("MakeEditable('{0}')", string.Format("_myDiv{0}", index)));
