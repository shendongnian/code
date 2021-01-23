 canberraTimetable = db.ShuttleTimeTables.Where(r => r.TimeTypeId == 5).ToList()
                                            .Where(r => (DateTime.Today.Date + r.Time) >= (DateTime.Today.Date + time_15))
                                            .Select(x => new SelectListItem()
                                            {
                                                Text = x.Time.Value.ToString(@"hh\:mm"),
                                                Value = x.Time.Value.ToString(@"hh\:mm")
                                            }).Take(3).ToList();</pre>
