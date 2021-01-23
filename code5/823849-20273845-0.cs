    var games = from g in file.Split(new[] {enter + enter}, StringSplitOptions.RemoveEmptyEntries)
                let gamestrings = g.Split(new[] {enter}, StringSplitOptions.RemoveEmptyEntries)
                let gamerecord = new {Name = gamestrings[0], Type = gamestrings[1], Difficulty = gamestrings[2]}
                where gamerecord.Type.Contains("RPG")
                select gamerecord;
