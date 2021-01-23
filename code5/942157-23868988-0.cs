                        date = Convert.ToDateTime(txtDate.Text);
                        string change = date.ToString("yyyy/MM/dd");
                        int day1 = Convert.ToInt32(change.Substring(8, 2));
                        int mon1 = Convert.ToInt32(change.Substring(5, 2));
                        int year1 = Convert.ToInt32(change.Substring(0, 4));
                        PersianCalendar pc = new PersianCalendar();
                        change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                        date = Convert.ToDateTime(change); 
