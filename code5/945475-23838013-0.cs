       .Return((l, g, p) => new {
           Localized = l.As<Xbox.Localization.Game>(),
           Game = g.As<Xbox.Game>(),
           LastPlayed = p.As<PlaysPayload>().LastPlayed  // <-- this line is different
       })
