    // Here is the container class we wish to serialize
            Transaction pc = new Transaction
            {
                amountSpecified=true,
                amount=23
            };
            // Serializer settings
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomResolver();
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            // Do the serialization and output to the console
            string json = JsonConvert.SerializeObject(pc, settings);
            Console.WriteLine(json);
