                        var ct = new ContentType("text/calendar");
                        if (ct.Parameters != null)
                        {
                            ct.Parameters.Add("method", "REQUEST");
                            ct.Parameters.Add("charSet", "utf-8");
                          
                            var avCal = AlternateView.CreateAlternateViewFromString(calendarAppt.ToString(), ct);
                            avCal.TransferEncoding = TransferEncoding.Base64;
                            mail.AlternateViews.Add(avCal);
                        }
