    public class LogExtension : ESRI.ArcGIS.Desktop.AddIns.Extension
      {
        public LogExtension()
        {
        }
    
        protected override void OnStartup()
        {
          ArcMap.Events.OpenDocument += new ESRI.ArcGIS.ArcMapUI.IDocumentEvents_OpenDocumentEventHandler(Events_OpenDocument);
        }
    
        void Events_OpenDocument()
        {
          System.Windows.Forms.MessageBox.Show("I opened a document.");
        }
    }
