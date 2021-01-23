    var coordinateTratteDict = doc.Descendants(ns + "Folder").First().Descendants(ns + "Folder")
        .Descendants(ns + "Placemark").Select((n,i) =>
        {
            string[] coordinates = n.Descendants(ns + "coordinates").First().Value.Split(' ');
            return new {
                Index = i
            ,   CoordList = coordinates
               .Select(coordinate => coordinate.Split(','))
               .Select(coordinateLatLng => new
                {
                    latitude = coordinateLatLng.Last(),
                    longitude = coordinateLatLng.First()
                })
                .ToList();
            };
        })
        .ToDictionary(p => "Block_"+p.Index, p => p.CoordList);
