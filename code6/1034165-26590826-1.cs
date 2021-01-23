    for(int i = 0; i < lists.length; i++){
        Console.Write(item.nickname
            .Where(x=> lists[i].match_id === item.match_id)
            .Select( z=> item.nickname)
            .FirstOrDefault());
    }
