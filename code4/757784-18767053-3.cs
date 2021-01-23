    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;
        public static Outlook.AppointmentItem theCurrentAppointment;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += new Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
        }
