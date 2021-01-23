       UpdateGameAttr(id ,  bal);
    
       private void UpdateGameAttr(int id, int bal)
       {
           XDocument gmaes = XDocument.Load(@"D:\xxx\xxx\Game.xml");            
    
           XElement upd = (from games in games.Descendants("savegame")
                          where games.Element("IdNumber").Value == id.ToString()
                          select games).Single();
           upd.Element("balance").Value = bal.ToString();
           gmaes.Save(@"D:\xxxx\xxx\Game.xml");
    
       }
