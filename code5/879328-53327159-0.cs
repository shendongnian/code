    services.AddMvc(c =>
                     {
                     ....
                     }).AddJsonOptions(options => {
                         options.SerializerSettings.Formatting = Formatting.Indented;
                         ....
                     })
