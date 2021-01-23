          if (e.Start.ToLocalTime() == res.Start && e.End.ToLocalTime() == res.End)
          {
               foreach (AttendeeType at in e.RequiredAttendees)
               {
         //attendee must accept meeting & attendee email    must match email in  reservation
                   if (at.ResponseType == ResponseTypeType.Accept  && at.Mailbox.EmailAddress == res.EmailAddress)
                   {
                       ce.Mailbox = at.Mailbox.EmailAddress;
                       ce.ApptStart = e.Start;
                       ce.ApptEnd = e.Start;
                       ce.ApptResponse = ResponseTypeType.Accept;
                       calevents.Add(ce);
                   }
               }
           }
