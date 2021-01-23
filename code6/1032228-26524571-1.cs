    var parsed = JObject.Parse(input);
    var result = new
        ListCoursesResponse
            {
                success = parsed["success"].Value<bool?>(),
                courses =
                    parsed.Properties()
                          .Where(prop => prop.Name != "success")
                          .ToDictionary(prop => prop.Name, 
                                        prop => prop.Value.ToObject<Course>())
            };
