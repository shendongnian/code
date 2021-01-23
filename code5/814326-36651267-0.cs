    public static IList<Entity> DeserializeJson(JToken inputObject)
        {
            IList<Entity> deserializedObject = new List<Entity>();
            
            foreach (JToken iListValue in (JArray)inputObject["root"])
            {
                Entity entity = new Entity();
                entity.DeserializeJson(iListValue);
                deserializedObject.Add(entity);
            }
            return deserializedObject;
        }
     public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject == null || inputObject.Type == JTokenType.Null)
            {
                return;
            }
            inputObject = inputObject["entity"];
            JToken assertions = inputObject["assertions"];
            if (assertionsValue != null && assertionsValue.Type != JTokenType.Null)
            {
                Assertions assertions = new Assertions();
                assertions.DeserializeJson(assertionsValue);
                this.Assertions = assertions;
            }
    // Continue Parsing
    }
