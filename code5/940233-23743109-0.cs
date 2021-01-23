    dynamic person = new
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe"
                };
    JsonSchemaGenerator schemaGenerator = new JsonSchemaGenerator {};
    JsonSchema schema = schemaGenerator.Generate(person.GetType());
