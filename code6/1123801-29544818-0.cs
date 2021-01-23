    foreach (var station in myCollection.GroupBy((s) => s.EstacionSensorEstacionNombre))
            {
                Console.WriteLine(station.Key); // station name
                foreach (var date in station.GroupBy((s) => s.Fecha))
                {
                    Console.WriteLine(date.Key.ToString() + "   " + date.Average(a => a.Valor)); //date + average value
                }
            }
