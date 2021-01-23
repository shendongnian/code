    protected void Page_Load(object sender, EventArgs e)
        {
    int? _LangID = TryParse2(Helper.GetAppSetting("LangID_En"));
    }
    int? TryParse2(string s) {
        int i;
        if (!int.TryParse(s, out i)) {
            return null;
        } else {
            return i;
        }
    }
