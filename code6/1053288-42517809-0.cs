    using System.Web.UI.HtmlControls;
    
    HtmlIframe newIframe = new HtmlIframe();
    newIframe.Src = "somewhere/some_page.html";
    myPlaceholder.Controls.Add(newIframe);
