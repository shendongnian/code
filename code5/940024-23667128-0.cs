    public partial class Event : EPiServer.TemplatePage<EventPage>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateProp.Visible = !CurrentPage.HideDate;
        }
    }
