            var queryTable = from rows in resultTable.AsEnumerable()
                             orderby rows.Field<double>("Value")
                             group rows by new
                             {
                                 Attrib1 = rows["Attrib1"],
                                 Attrib2 = rows["Attrib2"],
                                 Attrib3 = rows["Attrib3"],
                                 Attrib4 = rows["Attrib4"]
                             } into grp
                             select new
                             {
                                 Attrib1 = grp.Key.Attrib1,
                                 Attrib2 = grp.Key.Attrib2,
                                 Attrib3 = grp.Key.Attrib3,
                                 Attrib4 = grp.Key.Attrib4,
                                 Avg = grp.Average(s => Convert.ToDouble(s["Value"])),
                                 Min = grp.Min(s => Convert.ToDouble(s["Value"])),
                                 IDStringMin = grp.First().Field<string>("IDstring"),
                                 Max = grp.Max(s => Convert.ToDouble(s["Value"])),
                                 IDStringMax = grp.Last().Field<string>("IDstring"),
                                 Count = grp.Count()
                             };
