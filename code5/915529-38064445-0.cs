        public HttpResponseMessage GetStatChart()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var chartImage = new Chart(600, 400);
            chartImage.AddTitle("Chart Title");
            chartImage.AddSeries(
                    name: "Employee",
                    chartType: "Pie",
                    axisLabel: "Name",
                    xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
                    yValues: new[] { "2", "6", "4", "5", "3" });
            byte[] chartBytes = chartImage.GetBytes();
            response.Content = new ByteArrayContent(chartBytes);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            return response;
        }
