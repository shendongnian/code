    public partial class WebForm4 : System.Web.UI.Page
    {
      private string CreateLiCheckbox(string checkBoxText)
      {
        var checkState = !string.IsNullOrEmpty(Request.Form[string.Format("chk_{0}", checkBoxText)]) ? "checked=\"checked\"" : "";
    
        return string.Format("<li><span class=\"textDropdown\">{0}</span><input id=\"{1}\" name=\"chk_{0}\" value=\"{0}\" type=\"checkbox\" {2}><label for=\"{1}\"></label></li>",
          checkBoxText,
          checkBoxText + "dropdownID",
          checkState);
      }
      protected void Page_Load(object sender, EventArgs e)
      {
        int refreshtime = 5000;
        Timer1.Interval = refreshtime;
    
        if (!IsPostBack)
          PopulateCheckboxes();
      }
      protected void Timer1_Tick(object sender, EventArgs e)
      {
        PopulateCheckboxes();
      }
      private void PopulateCheckboxes()
      {
        string[] comps = new string[] { "default", "sales", "direct" };
        string html = "<ul>";
        for (int i = 0; i < comps.Count(); i++)
        {
          html = html + CreateLiCheckbox(comps[i]);
        }
        html = html + "</ul>";
        campaignDiv.InnerHtml = html;
      }
    }
