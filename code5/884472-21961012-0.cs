    public class JsonActionConverter : JsonCreationConverter<Action>
      {
        protected override Action Create(Type objectType, JObject jsonObject)
        {
          var typeName = jsonObject["ActionType"].ToString();
          switch(typeName)
          {
            case "Email":
              return new EmailAction();
            case "SMS":
              return new SMSAction();
            default: return null;
          }
        }
      }
