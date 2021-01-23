    using (FileStream fs = File.Open("config.json", FileMode.OpenOrCreate))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                jw.IndentChar = ' ';
                jw.Indentation = 4;
                config.WriteTo(jw);
            }
        }
    }
