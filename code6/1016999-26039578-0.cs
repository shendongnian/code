    [ToolboxItemAttribute(false)]
    public class addCustomToolPart : WebPart
    {
    private bool _intNumberofAnnouncement=10;
    [WebBrowsable(true),
        WebDisplayName("Number of announcement to display"),
        WebDescription("Controls number of announcement"),
        Category("Content Control"),
        Personalizable(PersonalizationScope.Shared)]
        public int NumberofAnnouncement { get { return _intNumberofAnnouncement; } set { _intNumberofAnnouncement = value; } }
    protected override void CreateChildControls()
        {
            webpartusercontrolclass control = (webpartusercontrolclass)Page.LoadControl(_ascxPath);
            control.addCustomToolPart = this;
            Controls.Add(control);
        }
    }
