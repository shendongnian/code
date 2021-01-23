    var vals = new List<string>();
    vals.Add(PlayerPosition.ToCsv());
    foreach (var trapPosition in TrapPositions)
        vals.Add(trapPosition.ToCsv());
    vals.Add(MonsterPosition.ToCsv());
    vals.Add(FlaskPosition.ToCsv());
    vals.Add(MonsterAwake.ToString());
    File.WriteAllText("filename.csv", string.Join(",", vals.ToArray());
