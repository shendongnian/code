    protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                switch (base.AssignmentTypeManagerIndex)
                {
                    case 1:
                        {
                            RadMultiPage1.SelectedIndex = 1;
                            RadTabStrip1.SelectedIndex = 1;
                            break;
                        }
                    case 2:
                        {
                            RadMultiPage1.SelectedIndex = 2;
                            RadTabStrip1.SelectedIndex = 2;
                            break;
                        }
                    default:
                        {
                            RadMultiPage1.SelectedIndex = 0;
                            RadTabStrip1.SelectedIndex = 0;
                            break;
                        }
                }
                base.AssignmentTypeManagerIndex = 0;
            }
        }
