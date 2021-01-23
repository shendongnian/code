            public List<EventBerichten> GetEventBerichtenLijst(int id)
            {
                var eventLijst = db.EventBericht.ToList();
                var berLijst = new List<EventBerichten>();
                foreach (var ber in eventLijst)
                {
                    if (ber.EventID == id )
                    {
                        berLijst.Add(ber);
                    }
                }
                return berLijst;
            }
