     //I CUT THE CODE WHERE I construct string[] t1 and int[] t2 these are just arrays
      public ActionResult EfficiencyChart(string pid) {
    
              
    
                var myChart = new Chart(width: 1000, height: 600)
                .AddTitle("Employee's Efficiency")
                .AddSeries(
                    name: "Employee",
                    xValue: t2,
                    yValues: t1)
                .Write();
    
                myChart.Save("~/Content/chart" + user.Id, "jpeg");
                // Return the contents of the Stream to the client
                return base.File("~/Content/chart" + user.Id, "jpeg");
            }
