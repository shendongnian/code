    using Newtonsoft.Json; // This is the namespace of Newtonsoft. 
    // this are the lines
    dynamic gameDataObj = JsonConvert.DeserializeObject(AllGameData);
    
    var newStr = string.Format("{{\"mapId\":\"{0}\", \"gameMode\":\"{1}\", \"gameType\":\"{2}\"}}", gameDataObj.mapId, gameDataObj.gameMode, gameDataObj.gameType);
