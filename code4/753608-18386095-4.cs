    var newRooms=new List<Room>(); // Get from service
    
    //Remove rooms no longer in use
    var matrix=matrix.Where(m=>newRooms.Select(nr=>nr.ID).Contains(m.Room.ID));
    //Find rooms we need to add (Optionally use Exclude for faster perf)
    var roomsToAdd=newRooms.Where(r=>matrix.Select(m=>m.Room.ID).Contains(r.ID));
    
    var maxLayer=matrix.Max(m=>m.layer);
    var rows = ?
    var cols = ?
    
    var positions=Enumerable
        .Range(0,maxLayer+1)
        .SelectMany(layer=>
            Enumerable
            .Range(0,rows)
            .SelectMany(row=>
                Enumerable
                    .Range(0,cols)
                    .Select(col=>new {layer,row,col})));
