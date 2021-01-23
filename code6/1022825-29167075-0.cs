    #region all using
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    #endregion
    
    namespace PartIndexerService
    {
        public partial class PartIndexer : ServiceBase
        {
            static string connectionString = "server=sql08-2.orcsweb.com;uid=bba-reman;password=_bba_1227_kol;database=BBAreman;Pooling=true;Connect Timeout=20;";
            SqlDependency dep;
    
            public PartIndexer()
            {
                InitializeComponent();
            }
    
            #region OnStart
            protected override void OnStart(string[] args)
            {
                RegisterNotification();
                MailNotify("STARTED");
            }
            #endregion
    
            #region RegisterNotification
            /// <summary>
            /// RegisterNotification
            /// this is main routine which will monitor data change in ContentChangeLog table
            /// </summary>
            private void RegisterNotification()
            {
                string tmpdata = "";
                System.Data.SqlClient.SqlDependency.Stop(connectionString);
                System.Data.SqlClient.SqlDependency.Start(connectionString);
    
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "SELECT ActivityDate FROM [bba-reman].ContentChangeLog";
                        dep = new SqlDependency(cmd);
                        dep.OnChange += new OnChangeEventHandler(OnDataChange);
                        SqlDataReader dr = cmd.ExecuteReader();
                        {
                            while (dr.Read())
                            {
                                if (dr[0] != DBNull.Value)
                                {
                                    tmpdata = dr[0].ToString();
                                }
                            }
                        }
                        dr.Dispose();
                        cmd.Dispose();
                    }
                }
                finally
                {
                    //SqlDependency.Stop(connStr);
                }
    
            }
            #endregion
    
            public void ReStartService()
            {
                ServiceController service = new ServiceController("PartIndexer");
    
                if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    service.Start();
                }
                else
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                }
            }
    
            #region OnDataChange
            /// <summary>
            /// OnDataChange
            /// OnDataChange will fire when after data change found in ContentChangeLog table
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void OnDataChange(object sender, SqlNotificationEventArgs e)
            {
                ((SqlDependency)sender).OnChange -= OnDataChange;
    
                if (e.Source == SqlNotificationSource.Timeout)
                {
                    var template = new MailTemplate()
                        .WithBody("HI,<br><br>Part Indexer Service Exception Timeout occur " + DateTime.Now.ToLongDateString())
                        .WithSubject("Part Indexer Service Exception Timeout occur")
                        .WithSender("bbasupport@bba-reman.com")
                        .WithRecepient("tridip@bba-reman.com")
                        .Send();
                    RegisterNotification();
                    return;
                }
                else if (e.Source != SqlNotificationSource.Data)
                {
                    var template = new MailTemplate()
                        .WithBody("HI,<br><br>Part Indexer Service Exception SqlNotificationSource.Data " + DateTime.Now.ToLongDateString())
                        .WithSubject("Part Indexer Service Exception SqlNotificationSource.Data")
                        .WithSender("bbasupport@bba-reman.com")
                        .WithRecepient("tridip@bba-reman.com")
                        .Send();
                    
                    Environment.Exit(1);
                }
    
                StartIndex();
                RegisterNotification();
            }
             #endregion
    
            #region StartIndex
            /// <summary>
            /// StartIndex
            /// this routine will call web service in bba reman website which will invoke routine to re-index data
            /// </summary>
            void StartIndex()
            {
                //eventLog1.WriteEntry("Web Service called start for indexing data"); 
    
                PartIndexerWS.AuthHeader oAuth = new PartIndexerWS.AuthHeader();
                oAuth.Username = "Admin";
                oAuth.Password = "Admin";
    
                PartIndexerWS.SearchDataIndex DataIndex = new PartIndexerWS.SearchDataIndex();
                DataIndex.AuthHeaderValue = oAuth;
                try
                {
                    DataIndex.StartIndex();
                    //eventLog1.WriteEntry("Web Service called stop for indexing data"); 
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.ToString());
                    //eventLog1.WriteEntry("Web Service call error "+ex.Message.ToString()); 
    
                }
               
            }
            #endregion
    
            #region MailNotify
            /// <summary>
            /// MailNotify
            /// fire mail when apps start & exit
            /// </summary>
            /// <param name="strStatus"></param>
            void MailNotify(string strStatus)
            {
                if (strStatus == "STARTED")
                {
                    var template = new MailTemplate()
                        .WithBody("HI,<br><br>Part Indexer Started Date " + DateTime.Now.ToLongDateString())
                        .WithSubject("Part Indexer Started")
                        .WithSender("bbasupport@bba-reman.com")
                        .WithRecepient("tridip@bba-reman.com")
                        .Send();
                    //eventLog1.WriteEntry("mail fired "); 
    
                }
                else if (strStatus == "STOPPED")
                {
                    var template = new MailTemplate()
                        .WithBody("HI,<br><br>Part Indexer stopped Date " + DateTime.Now.ToLongDateString())
                        .WithSubject("Part Indexer Stopped")
                        .WithSender("bbasupport@bba-reman.com")
                        .WithRecepient("tridip@bba-reman.com")
                        .Send();
                    //eventLog1.WriteEntry("mail fired "); 
                }
            }
            #endregion
    
            #region OnStop
            protected override void OnStop()
            {
                System.Data.SqlClient.SqlDependency.Stop(connectionString);
                MailNotify("STOPPED");
                //eventLog1.WriteEntry("Part Indexer stopped Date : " + DateTime.Now.ToLongDateString()); 
    
            }
            #endregion
        }
    }
