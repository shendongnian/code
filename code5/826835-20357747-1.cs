        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string _evt = this.Request["__EVENTTARGET"]; // 1st parameter
                string _eva = this.Request["__EVENTARGUMENT"]; // 2nd parameter
                switch (_evt)
                {
                    case "my_value":
                        //do anything here
                        break;
                    default:
                        break;
                }
            }
        }
