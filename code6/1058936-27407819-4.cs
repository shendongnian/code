            var schedule = JsonConvert.DeserializeObject<Foo>(jsonString);
            Debug.Assert(schedule.values.Count == 10); // No assert
            Debug.Assert(object.Equals(schedule.values["schedule[tuesday][1][time]"], "09:00")); // No assert
            Debug.Assert(schedule.values["schedule[tuesday][1][time]"].GetType() == typeof(string)); // No assert
            Debug.Assert(object.Equals(schedule.values["schedule[tuesday][1][active]"], true)); // No assert
            Debug.Assert(schedule.values["schedule[tuesday][1][active]"].GetType() == typeof(bool)); // No assert
