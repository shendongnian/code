    <script src="https://www.amcharts.com/lib/3/amcharts.js"></script>
    <script src="https://www.amcharts.com/lib/3/pie.js"></script>
    <script src="https://www.amcharts.com/lib/3/themes/light.js"></script>
     <script src="JSfiles/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var chartDataResults = new Array();
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'pichartssimple.aspx/GetDataonload',
                data: {},
                success: function (response) {
                    drawchart(response.d); // calling method
                },
    
                error: function () {
                    alert("Error:Something went wrong.Contact the Adminstrator");
                    alert(response);
                }
            });
    
            function drawchart(dataValues) {
               
                for (var i = 0; i < dataValues.length; i++) {
                    // data.addRow([dataValues[i].Accounts, dataValues[i].Accountvalues]);
                    var dataitem = dataValues[i];
    
                    var Account = dataitem.Accounts;
    
                    var Accountvalues = dataitem.Accountvalues;
                    // alert(Accountvalues);
    
                    chartDataResults.push({
                        Account: Account,
                        Accountvalues: Accountvalues
                    });
    
                    var chart = AmCharts.makeChart("chartdiv", {
                        "type": "pie",
                        "theme": "light",
                        "dataProvider": chartDataResults,
                        "valueField": "Accountvalues",
                        "titleField": "Account",
                        "balloon": {
                            "fixedPosition": true
                        },
                        "export": {
                            "enabled": true
                        }
                    });
                }
    
                // Instantiate and draw our chart, passing in some option
            }
        });
     </script>
    C#code
     [WebMethod(EnableSession = true)]
            public static List<Chatdata> GetDataonload()
            {
                List<Chatdata> dataList = new List<Chatdata>();
                using (SqlConnection con = new SqlConnection("Data Source=203.115.195.52;Initial Catalog=mcom_ad_engine;Persist Security Info=True;User ID=appl;Password=mcom007;"))
                {
    
                    //string StartDate = DateTime.Now.AddDays(-180).ToString("yyyy-MM-dd");
                    string StartDate = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd");
                    string EndDate = DateTime.Now.ToString("yyyy-MM-dd");
                    SqlCommand cmd = new SqlCommand("Sp_Advertiser_Monthly_payout_pichat", con);
                    cmd.CommandTimeout = 50;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iAdvertiser", "1000120");
                    cmd.Parameters.AddWithValue("@istartdate", StartDate);
                    cmd.Parameters.AddWithValue("@ienddate", EndDate);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
    
    
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        if (dtrow[0].ToString() != "Spent")
                        {
                            Chatdata details = new Chatdata();
    
                            details.Accounts = dtrow[0].ToString();
                            // details.spent = Convert.ToInt64(dtrow[2].ToString());
                            if (dtrow[1].ToString().StartsWith("-"))
                            {
                                string bal = dtrow[1].ToString();
                                bal = bal.Substring(1, bal.Length - 1);
                                details.Accountvalues = Convert.ToInt64(bal);
                            }
                            else
                            {
                                details.Accountvalues = Convert.ToInt64(dtrow[1].ToString());
                            }
                            dataList.Add(details);
                        }
                    }
    
                    return dataList;
                }
    
            }
            public class Chatdata
            {
                public string Accounts { get; set; }
                public Int64 Accountvalues { get; set; }
            }
