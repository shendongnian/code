    public void SendAppointment()
        {
            try
            {
                MailMessage msg = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                msg.From = new MailAddress("no-reply@email.com", "NEW EVENT");
                sc.Credentials = new NetworkCredential("no-reply@email.com", "password");
                sc.EnableSsl = true;
                msg.To.Add(new MailAddress("invited@mail.com", "Invited"));
                msg.Subject = "Subject";
                msg.Body = "YOUR CONTENT";
                StringBuilder str = new StringBuilder();
                str.AppendLine("BEGIN:VCALENDAR");
                str.AppendLine("PRODID:-//GeO");
                str.AppendLine("VERSION:2.0");
                str.AppendLine("METHOD:REQUEST");
                str.AppendLine("BEGIN:VEVENT");
                str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", START_DATE));
                str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmssZ}", DateTime.UtcNow));
                str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", END_DATE));
                str.AppendLine("LOCATION: " + Direccion);
                str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
                //str.AppendLine(string.Format("DESCRIPTION:{0}", msg.Body));
                str.AppendLine(string.Format("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:{0}", msg.Body));
            
                str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", msg.Body));
                str.AppendLine(string.Format("SUMMARY;ENCODING=QUOTED-PRINTABLE:{0}", msg.Subject));
                str.AppendLine(string.Format("ORGANIZER:MAILTO:{0}", msg.From.Address));
                str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", msg.To[0].DisplayName, msg.To[0].Address));
                str.AppendLine("BEGIN:VALARM");
                str.AppendLine("TRIGGER:-PT15M");
                str.AppendLine("ACTION:DISPLAY");
                str.AppendLine("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:Reminder");
                str.AppendLine("END:VALARM");
                str.AppendLine("END:VEVENT");
                str.AppendLine("END:VCALENDAR");
                System.Net.Mime.ContentType type = new System.Net.Mime.ContentType("text/calendar");
                type.Parameters.Add("method", "REQUEST");
                //type.Parameters.Add("method", "PUBLISH");
                type.Parameters.Add("name", "Cita.ics");
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(str.ToString(), type));
                sc.Send(msg);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
