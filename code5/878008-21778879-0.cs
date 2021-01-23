    public class WordApplication : Extensibility.IDTExtensibility2
    {
        private Microsoft.Office.Interop.Word.Application WordApp;
        private ICTPFactory myCtpFactory;
        private CustomTaskPane myPane;
        private tskPane myControl; //My UserControl
        public void OnConnection(object Application, Extensibility.ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            WordApp = Application as Microsoft.Office.Interop.Word.Application;
            WordApp.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(WordApp_DocumentOpen);
        }
        public void CTPFactoryAvailable(ICTPFactory CTPFactoryInst)
        {
            myCtpFactory = CTPFactoryInst;
        }
        void WordApp_DocumentOpen(Word.Document Doc)
        {
            if (isPaneRequired(Doc)) ShowSomeSortOfPane();
        }
        private bool isPaneRequired(Word.Document Doc) { return true; } //Lots of code not needed for example.
        private void ShowSomeSortOfPane()
        {
            myPane = myCtpFactory.CreateCTP("NameSpace.UserControlClassName", "My Task Pane", Type.Missing);
            myPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            myControl = (tskPane)myPane.ContentControl;
            myControl.CustomProperty = CustomValue;
            myPane.Visible = true;
        }
        public void OnDisconnection(Extensibility.ext_DisconnectMode RemoveMode, ref Array custom) { }
        public void OnStartupComplete(ref Array custom) { }
        public void OnAddInsUpdate(ref Array custom) { }
        public void OnBeginShutdown(ref Array custom) { }
    }
