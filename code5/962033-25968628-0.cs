    public static class SelectExtensionHelper
    {
        public static string SelectedValue(this System.Web.UI.HtmlControls.HtmlSelect select)
        {
            return select.Items[select.SelectedIndex].ToString();
        }
    }
