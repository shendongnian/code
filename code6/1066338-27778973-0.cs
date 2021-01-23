    public partial class _Default : System.Web.UI.Page
    {
    string[] arrMasterDDLSelItem;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (masterCheckBoxList.SelectedItem != null)
        {
            arrMasterDDLSelItem = new string[masterCheckBoxList.Items.Count];
            ListItem objListItem;
            for (int index = 0; index < masterCheckBoxList.Items.Count; index++)
            {
                objListItem = masterCheckBoxList.Items[index] as ListItem;
                if (objListItem.Selected)
                    arrMasterDDLSelItem[index] = objListItem.Text;
            }
            if (arrMasterDDLSelItem.Count() > 0)
                RecreateControls(arrMasterDDLSelItem);
        }
    }
    protected void typefilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList objCheckBoxList = sender as CheckBoxList;
        ListItem objListItem;
        string selectedItems=string.Empty;
        foreach (var item in objCheckBoxList.Items)
        {
            objListItem=item as ListItem;
            if (objListItem.Selected)
                selectedItems += " " + objListItem.Text + ",";
        }
        Label1.Text = selectedItems;
    }
    private SortedList<int, string> getFilterOptions(string selItem)
    {
        SortedList<int, string> filterValueList = new SortedList<int, string>();
        for (int index = 0; index < 10; index++)
            filterValueList.Add(index, "SubItem -" + index.ToString() + " For " + selItem);
        return filterValueList;
    }
    private void RecreateControls(string[] masterSelectedItem)
    {
        foreach (var item in masterSelectedItem)
        {
            if (item != null)
            {
                CheckBoxList typefilter = new CheckBoxList { ID = "typefilter" + item };
                typefilter.RepeatDirection = RepeatDirection.Horizontal;
                SortedList<int, string> filterValueList = new SortedList<int, string>();
                typefilter.AutoPostBack = true;
                typefilter.SelectedIndexChanged += new System.EventHandler(typefilter_SelectedIndexChanged);
                typefilter.DataTextField = "Value";
                typefilter.DataValueField = "Key";
                typefilter.DataSource = getFilterOptions(item);
                typefilter.DataBind();
                ContentPlaceHolder MainContent = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                MainContent.Controls.Add(typefilter);
            }
        }
    }
