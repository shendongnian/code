    public class IValueCheckGroupCreationConverter : JsonCreationConverter<IValueCheckGroup>
        {
            protected override IValueCheckGroup Create(Type objectType, JObject jsonObject)
            {
                bool isExpression = jsonObject["AsocDataFieldID"] == null ? false : true;
                if(isExpression) {
                        return new ValueCheckExpression ();
                } else {
                    return new ValueCheck();
                }   
            }
        }
