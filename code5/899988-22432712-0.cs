    void Page_Load (Object sender, EventArgs e) {
        if (!IsPostBack) {
            // non post back stuff
        }
        else {
            SQLDataSource1.Update ();
        }
    }
