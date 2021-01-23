    var deserializer = new DeserializerBuilder()
                .WithNodeTypeResolver(
                      new ExpandoNodeTypeResolver(), 
                      ls => ls.InsteadOf<DefaultContainersNodeTypeResolver>())
                .Build();
    dynamic result = deserializer.Deserialize(input);
