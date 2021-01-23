    var data = xmlDoc.Root;
    int money = (int)data.Element("money"); // 300
    int lives = (int)data.Element("lives"); // 10
    var waves = from w in data.Element("waves").Elements()
                select new {
                   Slimes = (int)w.Element("slimes"),
                   HealthPerSlime = (int)w.Element("healthPerSlime"),
                   Money = (int)w.Element("money")
                };
                    
