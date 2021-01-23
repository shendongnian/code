        public string getSummaryBarChartSeriesData(int userid)
        {
            var SeriesData = new List<Series>();
            DataTable dt = chartcode.RetrieveSummaryBarChartData(userid);
            int countOfRows = 0;
            foreach (DataRow row in dt.Rows)
            {
                var rawData = new List<IList<double>>();
                rawData.Add(new double[] { countOfRows++, Convert.ToInt32(row["CountOfStudents"]) });
                //objData.Add(row["Name"].ToString());
                SeriesData.Add(
                 new CareerClusterSeries
                 {
                     data = rawData,
                     color = "red",
                     label = row["Name"].ToString(),  // Guessing you wanted this.
                 });
            }
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(SeriesData);
            return json;
        }
