    var a=new PreLobbyPlayer { SPlayerId=1,DJoinDate=DateTime.Today };
    var b=new PreLobbyPlayer { SPlayerId=2,DJoinDate=DateTime.Today.AddDays(1) };
    var c=new PreLobbyPlayer { SPlayerId=1,DJoinDate=DateTime.Today.AddDays(2) };
    var set=new SortedSet<PreLobbyPlayer>();
    set.Add(b);
    set.Add(a);
    set.Add(c);
    foreach(var current in set) {
        Console.WriteLine("{0}: {1}",current.SPlayerId,current.DJoinDate);
    }
