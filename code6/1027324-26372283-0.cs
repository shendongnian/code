            var visit = new Visit();
            List<int> idsToKeep = new List<int>();
            visit.Client.Reverse();
            foreach(var thing in visit.Client){
                Client om = thing;
                if (om.ClientId == 0)continue;
                bool itemExists = false;
                foreach (int id in idsToKeep)
                    if (om.ClientId == id)
                        itemExists = true;
                if (!itemExists)
                {
                    visit.Client.Remove(thing);
                }
            }
            return errors;
