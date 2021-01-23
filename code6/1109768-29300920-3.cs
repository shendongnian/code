        using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using Bill.Constants;
    using Bill.Models.Reports;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using CrystalDecisions.Windows.Forms;
    
    namespace Example.Views.Reports
    {
        /// <summary>
        /// Interaction logic for ReportView.xaml
        /// </summary>
        public partial class ReportView : Window, INotifyPropertyChanged
        {
            public ReportView(Report report)
            {
                InitializeComponent();
    
                //WPF - not needed
                //this.ReportViewer.Owner = Window.GetWindow(this);  //added to fix null parameter window bug in Crystal report 
    
                if (Application.Current.MainWindow.IsLoaded)
                {
                    this.Owner = Application.Current.MainWindow;
                }
    
                WindowTitle = report.DisplayName;
                this.DataContext = this;
    
                ShowReport(report.FileInfo.FullName);
            }
    
            private string _windowTitle;
            /// <summary>
            /// Name of the report, shown in Window Title
            /// </summary>
            public string WindowTitle
            {
                get { return _windowTitle; }
                set
                {
                    if (_windowTitle != value)
                    {
                        _windowTitle = value;
                        FirePropertyChanged("WindowTitle");
                    }
                }
            }
    
            /// <summary>
            /// Show the selected report
            /// </summary>
            /// <param name="reportPath"></param>
            private void ShowReport(string reportPath)
            {
                ReportDocument report = new ReportDocument();
    
                if (!String.IsNullOrEmpty(reportPath))
                {
                    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfo = new ConnectionInfo();
                    Tables CrTables;
    
                    report.Load(reportPath);
    
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionStrings.CurrentConnection.ConnectionString);  //from config.xml
                    crConnectionInfo.ServerName = builder.DataSource;
                    crConnectionInfo.DatabaseName = builder.InitialCatalog;
                    crConnectionInfo.IntegratedSecurity = true;
    
                    CrTables = report.Database.Tables;
                    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                    {
                        crtableLogoninfo = CrTable.LogOnInfo;
                        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                        CrTable.ApplyLogOnInfo(crtableLogoninfo);
                    }
    //WinForms values
    
                    ReportViewer.ReportSource = report;
                    ReportViewer.EnableDrillDown = false;
                    //ReportViewer.AllowedExportFormats=ExportFormatType.
                    ReportViewer.ShowLogo = false;
                    ReportViewer.ShowRefreshButton = false;
                    ReportViewer.ShowParameterPanelButton = false;
                    ReportViewer.ShowGroupTreeButton = false;
                    ReportViewer.UseWaitCursor = false;
                    ReportViewer.ToolPanelView = ToolPanelViewType.None;
    
                    //report.Refresh();
                }
            }
    
            #region INotifyPropertyChange
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void FirePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    
            }
    
            #endregion
        }
    }
