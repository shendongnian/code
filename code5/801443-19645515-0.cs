    ViewBag.Clients = new SelectList(db.IPACS_Clients_Network
                                                   .Join(
                                                      db.IPACS_Clients,
                                                      v => v.networkClientID,
                                                      s => s.networkClientID,
                                                      (v, s) =>
                                                         new
                                                         {
                                                             v = v,
                                                             s = s
                                                         }
                                                   )
                                                   .Select(
                                                      temp0 =>
                                                         new
                                                         {
                                                             v = temp0.v,
                                                             s = temp0.s
                                                         }
                                                   ).Select(m => new SelectListItem
                                                   {
                                                       Value = SqlFunctions.StringConvert((double)m.s.clientID).Trim(),
                                                       Text = m.v.name + " - " + m.s.name
                                                   }), "Value", "Text", 0);
