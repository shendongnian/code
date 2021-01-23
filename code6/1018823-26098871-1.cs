    public ActionResult EfficiencyChart(int pid)
    {
    var myChart = new Chart(width: 1000, height: 600)
            .AddTitle("Employee's Efficiency")
            .AddSeries(
                name: "Employee",
                xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" },
                yValues: new[] { "2", "6", "4", "5", "3" })
            .Write();
            myChart.Save("~/Content/chart" + pid, "jpeg");
            return base.File("~/Content/chart" + pid, "jpeg");
    }
