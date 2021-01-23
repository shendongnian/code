    public class PageHome : Page
    {
        // Do you really not need to initialize this to something else?
        int _PageID = 0;
        int _LangID;
        int _PID;
        public PageHome()
        {
            _LangID = int.Parse(Helper.GetAppSetting("LangID_En"));
            _PID = Helper.GetPageID(_LangID, "Home.aspx");
        }
        ...
    }
