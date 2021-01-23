    var dateMeasurements = new Dictionary<DateTime, List<ElementMeasurement>>();
    using(var con = new SqlConnection("ConnectionString"))
    using (var cmd = new SqlCommand("SELECT e.* FROM Elements e ORDER BY Date,ElementId,Field,Value", con))
    {
        con.Open();
        using (var rd = cmd.ExecuteReader())
        while(rd.Read())
        {
            DateTime timeOfMeasurement = rd.GetDateTime(rd.GetOrdinal("Date"));
            DateTime dateOfMeasurement = timeOfMeasurement.Date;
            List<ElementMeasurement> measurements = null;
            if (!dateMeasurements.TryGetValue(dateOfMeasurement, out measurements))
            {
                measurements = new List<ElementMeasurement>();
                dateMeasurements.Add(dateOfMeasurement, measurements);
            }
            var measurement = new ElementMeasurement
            {
                Element = new Element { ElementId = rd.GetInt32(rd.GetOrdinal("ElementId")) },
                Field = rd.GetString(rd.GetOrdinal("Field")),
                Value = rd.GetDouble(rd.GetOrdinal("Value")),
                TimeOfMeasurement = timeOfMeasurement
            };
            measurements.Add(measurement);
        }
    }
