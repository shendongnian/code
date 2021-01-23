        using System.Data.SqlClient;
        namespace MyNamespace
        {
            public class Task
            {
                public string strTaskName { get; set; }
                public string strTaskDetail { get; set; }
                public string strTaskStartDate { get; set; }
                public string strIdentifier { get; set; }
                public string strStatus { get; set; }
                public string strDueDate { get; set; }
                public string strIssueDate { get; set; }
                public string strCompleted { get; set; }
                public string strNotes { get; set; }
                public string strProvider { get; set; }
                public string strService { get; set; }
                public string strCheckedDate { get; set; }
                public string strCheckedStatus { get; set; }
                public string strCheckedUser { get; set; }
                public string strClient { get; set; }
                // you need to define properties for the appropriate datatype on these
                //hfMemoID
                //hfObjectID
                public string strConn { get; set; }
                public void Load(string objectid)
                {
                    var strMainSql = @"SELECT
                        CT.OBJECTID 'Object ID'
                FROM HSI.RMOBJECTINSTANCE1224 CT
                WHERE CT.ACTIVESTATUS = 0 AND CT.OBJECTID = '" + objectid + "'";
                    using (SqlConnection scConn = new SqlConnection(strConn))
                    {
                        scConn.Open();
                        using (SqlCommand scComm = new SqlCommand(strMainSql, scConn))
                        {
                            var sdrRead = scComm.ExecuteReader();
                            while (sdrRead.Read())
                            {
                                /* CAN BE USED IN OTHER PAGES */
                                this.strTaskName = sdrRead[1].ToString();
                                this.strTaskDetail = sdrRead[2].ToString();
                                this.strTaskStartDate = sdrRead[3].ToString();
                                this.strIdentifier = sdrRead[4].ToString();
                                this.strStatus = sdrRead[5].ToString();
                                this.strDueDate = sdrRead[6].ToString();
                                this.strIssueDate = sdrRead[7].ToString();
                                this.strCompleted = sdrRead[8].ToString();
                                this.strNotes = sdrRead[9].ToString();
                                this.strProvider = sdrRead[10].ToString();
                                this.strService = sdrRead[11].ToString();
                                this.strCheckedDate = sdrRead[12].ToString();
                                this.strCheckedStatus = sdrRead[13].ToString();
                                this.strCheckedUser = sdrRead[14].ToString();
                                this.strClient = sdrRead[15].ToString();
                                // 
                                //hfMemoID.Value = sdrRead[16].ToString();
                                //hfObjectID.Value = sdrRead[0].ToString();
                                break;
                            }
                        }
                    }
                }
            }
        }
