        public ActionResult OpenTickets()
        {
            
            List<OpenTickets> openTicketList = new List<OpenTickets>();//create a list of openTickets
            
            var Tickets = db.Ticket//select the tickets that you want
                .Where(t => t.idFirma == 1)
                .Where(t => t.Zatvoren == false);
            
            foreach (var ticket in Tickets)//Loop over the tickets and create an openTicket out of each ticket then add the openTick to the openTicketList
            {
                OpenTickets openTicket = new OpenTickets();//create new OpenTickets object
                openTicket.propery1 = ticket.propery1;//set each property of the openTicket equal to the property of the Ticket that you want to keep
                openTicket.propery2 = ticket.propery2;
                openTicket.propery3 = ticket.propery3;
                openTicket.propery4 = ticket.propery4;
                openTicketList.Add(openTicket);//add new OpenTickets object to the list
            }
            return View(openTicketList);
        }
