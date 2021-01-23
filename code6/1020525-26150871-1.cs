    public partial class Default : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            int last = 20;
            int lastitem;
            for (int i = 1; i < last; i++)
            {
                lastitem = i + 1;
                categoriesCombo.Items.Add(new RadComboBoxItem(i.ToString() + "-" + lastitem.ToString()));
            }
        }
    }
