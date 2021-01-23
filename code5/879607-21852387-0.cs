    public class DataPagerDDL : DataPager
    {
        protected override void OnInit(EventArgs e)
        {
            CreateDefaultPagerFields();
            base.OnInit(e);
        }
        
        protected virtual void CreateDefaultPagerFields()
        {
            //add custom template
            TemplatePagerField templateField = new TemplatePagerField();
            templateField.PagerTemplate = new CustomTemplate();
            Fields.Add(templateField);
    
            //add previous/next page template
            NextPreviousPagerField nextPreviousField = new NextPreviousPagerField();            
            nextPreviousField.ShowFirstPageButton = false;
            nextPreviousField.ShowLastPageButton = false;
            nextPreviousField.PreviousPageText = "<<";
            nextPreviousField.NextPageText = ">>";
            Fields.Add(nextPreviousField);
        }
    
        public void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList cmbPage = (DropDownList)sender;
            SetPageProperties(cmbPage.SelectedIndex * MaximumRows, MaximumRows, true);
        }
    }
    
    public class CustomTemplate : ITemplate
    {
        public void InstantiateIn(Control container)
        {
            DataPagerFieldItem caller = (DataPagerFieldItem)container;
            DataPagerDDL pager = (DataPagerDDL)caller.Parent;
            int totalPages = pager.TotalRowCount / pager.MaximumRows;
            if (pager.TotalRowCount % pager.MaximumRows > 0) totalPages += 1;
            int currentPage = (pager.StartRowIndex / pager.MaximumRows) + 1;
    
            DropDownList cmbPage = new DropDownList();
            cmbPage.ID = "cmbPage";
            cmbPage.AutoPostBack = true;
            cmbPage.SelectedIndexChanged += pager.cmbPage_SelectedIndexChanged;
            
            for (int i = 1; i <= totalPages; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                if (i == currentPage) item.Selected = true;
                cmbPage.Items.Add(item);
            }
    
            container.Controls.Add(new LiteralControl("Page "));
            container.Controls.Add(cmbPage);
            container.Controls.Add(new LiteralControl(" of " + totalPages + " pages | "));
        }
    }
