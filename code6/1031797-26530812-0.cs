     // Quering all Newly Registered Users by Day
            var queryUsers = _appUserService.GetAllUsers()
                .Where(w => w.SignupDate.Month == DateTime.Now.Month)
                .GroupBy(g => g.SignupDate.Day)
                .OrderBy(o => o.Key)
                .Select(grp => new { Day = grp.Key, Count = grp.Count() });
            int[] userCategories = queryUsers.Select(x => x.Day).ToArray();
            string[] resultUserCategories = userCategories.Select(x => x.ToString()).ToArray();
            int[] userData = queryUsers.Select(x => x.Count).ToArray();
            object[] userObjArry = userData.Cast<object>().ToArray();
            DotNet.Highcharts.Highcharts userChart = new DotNet.Highcharts.Highcharts("userchart")
            .SetXAxis(new XAxis
            {
                Categories = resultUserCategories
            }
            )
            .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
            .SetTitle(new Title { Text = "Daily Record" })
            .SetSubtitle(new Subtitle { Text = "Total Count" })
            .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Approximate Count" } })
            .SetSeries(new[]{
            new Series
            {
                Name = Convert.ToString("Number of New Users"),
                Data = new Data(userObjArry)
            }
            });
            return PartialView("_Users", userChart);
