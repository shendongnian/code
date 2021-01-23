        public static Results ToDimensionResults(this GaData ga)
        {
            var results = new Results();
            var dimensions = new List<Dimension>();
            List<Metric> metrics;
            var value = "";
            var metricStartIndex = 1;
            for (var i = 0; i < ga.Rows.Count; i++)
            {
                //accomodate data without dimensions
                if (!string.IsNullOrEmpty(ga.Query.Dimensions))
                {
                    value = ga.Rows[i][0].ToString();
                }
                else
                {
                    value = "";
                    metricStartIndex = 0;
                }
                metrics = new List<Metric>();
                for (var x = metricStartIndex; x < ga.Rows[i].Count; x++)
                {
                    metrics.Add(new Metric
                    {
                        Value = Convert.ToInt32(ga.Rows[i][x])
                    });
                }
                dimensions.Add(new Dimension
                {
                    Value = value,
                    Metrics = metrics
                });
            }
            results.Dimensions = dimensions;
            return results;
        }
