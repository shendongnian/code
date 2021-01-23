    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string msgCancelProject = "You are not authorized to cancel the project.";
    
                if (IsAuthorized)
                {
                    CancelProject.Attributes.Add("title", msgCancelProject);
                    CancelProject.Attributes.Add("clickDisabled", "disable"); // I'm not sure what you are trying to do here
                }
                else
                {
                    CancelProject.Attributes.Remove("title");
                    CancelProject.Attributes.Remove("clickDisabled");
                }
            }
        }
