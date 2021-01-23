    public partial class Specialist_Pers : DotNetNuke.Entities.Modules.PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AgendaPlanner1.SetAgenda();
        }
    }
