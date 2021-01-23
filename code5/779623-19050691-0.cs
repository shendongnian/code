        //Global ViewState Variables
        private DataTable networksInfo;
        private string HHmm;
        private string Window;
        private string ZoomFactorTop;
        private string ZoomFactorBottom;
        protected Boolean autoRefresh; 
        /// <summary>
        /// This page prerender allows me to save viewstate objects before anything bad
        /// happens. It's going to save any data that needs to persist across postbacks,
        /// since the page refreshes with an autorefresh. Whenever updated, the ViewState
        /// will also need to be updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Page_PreRender(object sender, EventArgs e)
        {
            // Save the ViewStateObjects before the page is rendered.
            ViewState.Add("networksListVS", networksInfo);
            ViewState.Add("HHmmVS", HHmm);
            ViewState.Add("WindowVS", Window);
            ViewState.Add("ZoomFactorTopVS", ZoomFactorTop);
            ViewState.Add("ZoomFactorBottomVS", ZoomFactorBottom);
            ViewState.Add("AutoRefresh", autoRefresh);
        }
        protected void Create_ViewState(DateTime now)
        {
            //Populate Dropdown handles the initial value for networksInfo, but none of the others are
            //Set ViewState Vars' initial values
            if (ViewState["HHmmVS"] == null)
            {
                int HH = now.Hour;
                int mm = now.Minute;
                Change_Time(HH, mm);
            }
            if (ViewState["WindowVS"] == null)
            {
                //The default time window to view is 6 hours
                Window = "6";
            }
            if (ViewState["ZoomFactorTopVS"] == null)
            {
                //The default zoom factor is Window + 0
                ZoomFactorTop = "0";
            }
            if (ViewState["ZoomFactorBottomVS"] == null)
            {
                //The default zoom factor is Window + 0
                ZoomFactorBottom = "0";
            }
            if(ViewState["AutoRefresh"] == null)
            {
                autoRefresh = true;
            }
        }
        protected void Load_ViewState()
        {
            //Before updating the charts, we know that this is a postback and that the viewstate shouldn't
            //be null, but check anyways, just to be sure
            if (ViewState["networksListVS"] != null)
            {
                networksInfo = (DataTable)ViewState["networksListVS"];
            }
            if (ViewState["HHmmVS"] != null)
            {
                HHmm = (String)ViewState["HHmmVS"];
            }
            if (ViewState["WindowVS"] != null)
            {
                Window = (String)ViewState["WindowVS"];
            }
            if (ViewState["ZoomFactorTopVS"] != null)
            {
                ZoomFactorTop = (String)ViewState["ZoomFactorTopVS"];
            }
            if (ViewState["ZoomFactorBottomVS"] != null)
            {
                ZoomFactorBottom = (String)ViewState["ZoomFactorBottomVS"];
            }
            if (ViewState["AutoRefresh"] != null)
            {
                autoRefresh = (Boolean)ViewState["AutoRefresh"];
            }
        }
