    [WebMethod]
        public static string GetChart1(string account)
        {
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@account", account) };
            DataSet ds = Utility.ExecuteDataTable("GetChart1", param);
            if (ds.Tables[0].Rows.Count != 0)
            {
                VarianceChartModel bar = new VarianceChartModel();
                bar.labels = ds.Tables[0].Rows[0][0].ToString().Split(',');
                bar.datasets = new List<datasets>();
                for (int i = 1; i < ds.Tables.Count; i++)
                {
                    string data = ds.Tables[i].Rows[0][0].ToString();
                    if (!string.IsNullOrEmpty(data))
                    {
                        datasets dataset = new datasets();
                        dataset.data = Array.ConvertAll(data.Split(','), decimal.Parse);
                        dataset.label = "new";
                        dataset.fillColor = "rgba(255, 102, 0,0.5)";
                        dataset.highlightFill = "rgba(255, 102, 0,0.75)";
                        dataset.highlightStroke = "rgba(255, 102, 0,0.50)";
                        dataset.strokeColor = "rgba(255, 102, 0,0.8)";
                        bar.datasets.Add(dataset);
                    }
                }
                var serializer = new JsonSerializer();
                var stringWriter = new StringWriter();
                var writer = new JsonTextWriter(stringWriter);
                // writer.QuoteName = false;
                serializer.Serialize(writer, bar);
                writer.Close();
                var json = stringWriter.ToString();
                return json.ToString();
            }
            else
            {
                return null;
            }
        }
