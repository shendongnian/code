     if (ModelState.IsValid)
            {
                if (cmd == "Save")
                {
                    try
                    {
                        var plyr = new player();
                     
                    /*    db.players.Add(Player);
                       
                      //  player pl = db.players.Where(m => m.team == null).FirstOrDefault();
                     //   Player.team = team;
                        db.SaveChanges();*/
                        plyr.playerName = Player.playerName;
                        plyr.team = team;
                        plyr.position = Player.position;
                        plyr.email = Player.email;
                        plyr.type = Player.type;
                        plyr.height = Player.height;
                        db.players.Add(plyr);
                        db.SaveChanges();
                        return RedirectToAction("Index/" + TeamId);
                       
                        
                    
                    }
                    catch { }
                }
