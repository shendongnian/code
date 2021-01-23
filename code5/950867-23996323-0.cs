    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class Form1
    {
	private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		HtmlElementCollection item = default(HtmlElementCollection);
		item = WebBrowser1.Document.GetElementsByTagName("span");
		HtmlElement ht = default(HtmlElement);
		foreach ( ht in item) {
			Interaction.MsgBox(ht.DomElement.attributes("class").value.ToString);
		}
	}
    }
