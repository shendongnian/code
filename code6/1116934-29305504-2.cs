            if (!String.IsNullOrWhiteSpace(model.DrillDown))
            {
                switch (model.SelectedInterval)
                {
                    case TimeInterval.Weekly:
                        model.FromDate = DateTime.ParseExact(model.DrillDown,"yyyy/MM/dd",CultureInfo.InvariantCulture);
                        model.ThroughDate = model.FromDate.AddDays(6);
                        break;
                    case TimeInterval.Monthly:
                        model.FromDate = DateTime.ParseExact(model.DrillDown+"/01", "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        model.ThroughDate = model.FromDate.AddMonths(1).AddDays(-1);
                        break;
                    case TimeInterval.Annual:
                        model.FromDate = DateTime.ParseExact(model.DrillDown + "/01/01", "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        model.ThroughDate = model.FromDate.AddYears(1).AddDays(-1);
                        break;
                    case TimeInterval.Daily:
                        model.FromDate = DateTime.ParseExact(model.DrillDown, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        model.ThroughDate = model.FromDate;
                        break;
                }
            }
            var through = model.ThroughDate.AddDays(1);
            var drilldownQuery = DataManager.DataSessions
                .Include("Location")
                .Include("Quote.Carriers")
                .Include("Drivers")
                .Include("Vehicles")
                .Where(session =>
                    session.Timestamp >= model.FromDate &&
                    session.Timestamp < through
                );
            if (!String.IsNullOrWhiteSpace(model.DrillDown))
            {
                switch (model.SelectedInterval)
                {
                    case TimeInterval.Hourly:
                        int selectedHour = int.Parse(model.DrillDown);
                        drilldownQuery = drilldownQuery.Where(session => session.Timestamp.Hour == selectedHour);
                        break;
                    case TimeInterval.Weekday:
                        var selectedWeekday = (DayOfWeek) int.Parse(model.DrillDown);
                        drilldownQuery =
                            drilldownQuery.Where(
                                session => session.Timestamp.DayOfWeek == selectedWeekday);
                        break;
                }
            }
            return query;
        }
