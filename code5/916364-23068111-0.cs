            Table AppointmentTable = new Table();
            DateTime time = startTime;
            while (time <= endTime)
            {
                TableRow tblr_row = new TableRow();
                TableCell tblc_cell = new TableCell();
                TableCell tblc_time = new TableCell();
                try
                {
                    if(Appointments.checkIfBookingExsists(time) == true)
                    {
                        tblc_time.Text = time.ToString("HH:mm");
                        tblc_cell.Text = "Booked";
                        tblc_cell.CssClass = "Booked";
                    }
                    else if(Appointments.checkIfBookingExsists(time) == false)
                    {
                        tblc_time.Text = time.ToString("HH:mm");
                        tblc_cell.Text = "Book";
                        tblc_cell.CssClass = "Book";
                    }
                   
                }
                catch (Exception ex)
                {
                    tblc_time.Text = time.ToString("HH:mm");
                    tblc_cell.Text = ex.Message;
                }
                tblc_time.CssClass = "tableCell";
                tblr_row.Controls.Add(tblc_time);
                tblr_row.Controls.Add(tblc_cell);
                AppointmentTable.CssClass = "table1";
                AppointmentTable.Controls.Add(tblr_row);
                //Move interval 16:10 > 16:20 interval 10 minutes
                time = time.Add(interval);
            }
            Page.Controls.Add(AppointmentTable);
