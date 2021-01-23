    public class MyRibbon: Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            // ensure that any new inspectors created have a callback to refresh the button state on ativation.
            Globals.ThisAddIn.Application.Inspectors.NewInspector += Inspectors_NewInspector;
        }
        void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            ((Outlook.InspectorEvents_10_Event)Inspector).Activate += Inspector_Activate;
        }
        void Inspector_Activate()
        {
            ribbon.Invalidate();
        }
    }
