    namespace WpfApplication4
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
       public partial class MainWindow : Window
       {
        BackgroundWorker _backgroundWorker = new BackgroundWorker();  
          public MainWindow()
          {
              InitializeComponent();
              _backgroundWorker.DoWork += _backgroundWorker_DoWork;
              _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
              _backgroundWorker.WorkerReportsProgress = true;  
             _backgroundWorker.RunWorkerAsync(); 
  
        }
        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var  recordings  = GetRecordings(ctrl_inFileDir.Text, wmcTypes,     ctrl_useMCEDir.Checked, ctrl_mceDir.Text);  
            int recCount =  recordings.Count; 
            int i=0 ;  
            foreach (var recording in recordings )
            {
                XElement  xDoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),new  XElement("Recording",
                       new XElement("oid", r.oid),
                       new XElement("name", r.name),
                       new XElement("channel", r.channel),
                       new XElement("filename",r.filename),
                       new XElement("status",r.status),
                       new XElement("startTime",r.startTime),
                       new XElement("endTime",r.endTime),
                       new XElement("Event",
                           new XElement("OID",r.EventOID),
                           new XElement("Title",r.EventTitle),
                           new XElement("SubTitle",r.EventSubTitle),
                           new XElement("Description",r.EventDescription),
                           new XElement("ChannelOID",r.EventOID),
                           new XElement("StartTime",r.EventStartTime),
                           new XElement("EndTime",r.EventEndTime));
                _backgroundWorker.ReportProgress(i/recCount);
                
                     
            }
        }
        void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgBar.Value = e.ProgressPercentage;  
        }
    }
