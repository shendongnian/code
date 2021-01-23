    public partial class LeaveBalance : System.Web.UI.Page
    {
         // This is your UI logic.
        /// <summary>
        /// Create a private variable to hold all your leave retrieved from the database
        /// I assume you have you'll have one row for each leave type
        /// </summary>
        public LeaveCollection AllLeaves {
            get
            {
                if (ViewState["AllLeaves"] != null)
                {
                    return (LeaveCollection)ViewState["AllLeaves"];
                }
                return new LeaveCollection();
            }
            set
            {
                // You need to save the collection in ViewState to persist the data
                // Otherwise you'll loose all values AllLeaves will be reset in every postback
                ViewState["AllLeaves"] = value;
            }
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllLeavesFromDatabase();
            }
    
            // I assume that annual leave radio option will be selected initially when the page loads
            LoadDisplayTable(LeaveType.AL);
        }
    
        protected void rblleavetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeaveType type = LeaveType.AL;
    
            switch (rblleavetype.SelectedValue)
            {
                case "ml":
                    type = LeaveType.ML;
                    break;
                case "sp":
                    type = LeaveType.SP;
                    break;
            }
    
            LoadDisplayTable(type);
        }
    
        /// <summary>
        /// Gets all leaves from database.
        /// </summary>
        private void GetAllLeavesFromDatabase()
        {
            AllLeaves = new LeaveCollection();
            /* At this point you should know how to retrieve your leave data from DB and fill the allLeaves collection
             E.g.
             
             allLeaves = DalService.GetAllLeavesFromDatabase(); // DalService could be your Data Access layer and GetAllLeavesFromDatabase() is one of it's methods
             
             I'll be creating some dummy logic to fill the collection for demo purpose from this point onwards
             
             */
    
            // Add annual leave to the collection
            Leave al = new Leave(LeaveType.AL);
            al.TotalDays = 15;
            al.Available = 10;
            AllLeaves.Add(al);
    
            // Add Maternity leave
            Leave ml = new Leave(LeaveType.ML);
            ml.TotalDays = 60;
            ml.Available = 5;
            AllLeaves.Add(ml);
    
            // Add Special leave
            Leave sl = new Leave(LeaveType.SP);
            sl.TotalDays = 5;
            sl.Available = 3;
            AllLeaves.Add(sl);
        }
    
        private void LoadDisplayTable(LeaveType type)
        {
            Leave selectedLeave = new Leave(type);
    
            if (AllLeaves != null && AllLeaves.Count > 0)
            {
                // Here we find the leave object in the collection based on the leave type
                selectedLeave = AllLeaves.Find(a => a.LeaveType == type);
            }
    
            // Populate your labels with selected leave type
            ltotalleavetype.Text = selectedLeave.TotalDays.ToString();
            lbalanceleavetype.Text = selectedLeave.Available.ToString();
        }
    }
