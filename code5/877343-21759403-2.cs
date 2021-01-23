        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CalendarDataContext db = new CalendarDataContext();
                var evt = db.CalendarEvents(NumberToDisplay, Department);
                if (Department == "List")
                {
                    foreach (CalendarEventsResult cer in evt)
                    {
                        BuildEventsList(cer.event_name, cer.event_start_date, cer.event_idn, cer.information_id);
                    }
                }
                else
                {
                    // Depending what type evt is may depend on how to convert to the List.
                    // This assumes that it supports IEnumerable (like DataTable) 
                    List<CalendarEventsResult> events = evt.AsEnumerable().ToList();
                    // Rather than hard-coding, read this from config or database 
                    // to allow easier changing to a different number of events per row?
                    int numberOfEventsPerRow = 3;
                    // loop increments in steps of 3 (numberOfEventsPerRow)
                    for (int rowNumber = 0; rowNumber < events.Count; rowNumber += numberOfEventsPerRow)
                    {
                        // use Linq to pick out the subset of Events to process
                        List<CalendarEventsResult> queryEvents = events
                            .Skip(numberOfEventsPerRow * rowNumber)
                            .Take(numberOfEventsPerRow).ToList<CalendarEventsResult>();
                        // Build a row using that subset
                        TableRow tr = buildRow(queryEvents, numberOfEventsPerRow);
                        // Add it to the table
                        tblEvents.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                // this just suppresses any exceptions. Better to fix issues at source.
            }
        }
        private TableRow buildRow(List<CalendarEventsResult> events, int eventsPerRow)
        {
            TableRow tr = new TableRow();
            // Can these be added to CSS?
            tr.HorizontalAlign = HorizontalAlign.Center;
            tr.VerticalAlign = VerticalAlign.Bottom;
            tr.Height = Unit.Pixel(80);
            TableCell tc;
            // for our event subset, build a pair of cells for each Event,
            // adding them to a row
            foreach (var evt in events)
            {
                tc = BuildEventDate(evt);
                tr.Cells.Add(tc);
                tc = BuildEventTitle(evt);
                tr.Cells.Add(tc);
            }
            // If we're dealing with a partial row, i.e. only 1 or 2 Events,
            // pad the row with empty cells.
            if (events.Count < eventsPerRow)
            {
                tc = BuildEmptyCell(eventsPerRow - events.Count);
                tr.Cells.Add(tc);
            }
            return tr;
        }
        private TableCell BuildEventDate(CalendarEventsResult evt)
        {
            TableCell tc = new TableCell();
            Literal litDate = new Literal();
            //String.Format should suffice c.f. StringBuilder
            litDate.Text = String.Format("<div class='EventDate'>{0}{1}</div>", ShortMonth(evt.Month), evt.Day.ToString());
            tc.Controls.Add(litDate);
            return tc;
        }
        private TableCell BuildEventTitle(CalendarEventsResult evt)
        {
            TableCell tc = new TableCell();
            int evtInfoId = evt.information_id - 1;
            Literal litTitle = new Literal();
            // n.b. hard-coded URL doesn't look good for ease of maintenance (move to config or CalendarEventsResult?)
            litTitle.Text = String.Format(@"<div class='EventTitle'><a style='text-decoration:none;' href='http://events.website.edu/EventList.aspx?view=EventDetails&eventidn={0}&information_id={1}&type=&rss=rss'>{2}</a></div>", 
                evt.event_idn.ToString().Trim(), evtInfoId, evt.event_name);
            tc.Controls.Add(litTitle);
            return tc;
        }
        private TableCell BuildEmptyCell(int numberOfEvents)
        {
            // Define as const rather than having unexplained "2" hard-coded.
            const int spanPerEvent = 2;
            TableCell tc = new TableCell();
            tc.ColumnSpan = spanPerEvent * numberOfEvents;
            tc.Text = "";
            return tc;
        }
    }
