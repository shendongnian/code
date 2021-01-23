    protected void btnGetValues_Click(object sender, EventArgs e)
    {
	XDocument xdoc = XDocument.Load(Server.MapPath("~/data.xml"));
	XNamespace ns = "http://winscp.net/schema/session/1.0";
	StringBuilder Sb = new StringBuilder();
	try {
		//iterate within xmlelement where assume with this code that "session" is root
		//and descendant are upload and its child and touch with its childs
		foreach (object el_loopVariable in (from a in xdoc.Root.Descendants(ns + "upload")a)) {
			el = el_loopVariable;
			foreach (object subelement_loopVariable in el.Descendants) {
				subelement = subelement_loopVariable;
				Response.Write("<b>" + subelement.Name.ToString + "</b><ul>");
				if (subelement.HasAttributes) {
					foreach (object att_loopVariable in subelement.Attributes) {
						att = att_loopVariable;
						Response.Write("<li>" + att.Name.ToString + ":" + att.Value.ToString + "</li>");
					}
				}
				Response.Write("</ul>");
			}
		}
	} catch (Exception ex) {
		Response.Write(ex.Message);
	}
    }
    
    
