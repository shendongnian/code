    class SnakeCaseContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            // if the property does not have a JsonPropertyAttribute applied, use Snake Case
            if (!member.CustomAttributes.Any(att => att.AttributeType == typeof(JsonPropertyAttribute)))
            {
                prop.PropertyName = GetSnakeCase(prop.PropertyName);
            }
            return prop;
        }
        private string GetSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            var buffer = "";
            for (var i = 0; i < input.Length; i++)
            {
                var isLast = (i == input.Length - 1);
                var isSecondFromLast = (i == input.Length - 2);
                var curr = input[i];
                var next = !isLast ? input[i + 1] : '\0';
                var afterNext = !isSecondFromLast && !isLast ? input[i + 2] : '\0';
                buffer += char.ToLower(curr);
                if (!char.IsDigit(curr) && char.IsUpper(next))
                {
                    if (char.IsUpper(curr))
                    {
                        if (!isLast && !isSecondFromLast && !char.IsUpper(afterNext))
                            buffer += "_";
                    }
                    else
                        buffer += "_";
                }
                if (!char.IsDigit(curr) && char.IsDigit(next))
                    buffer += "_";
                if (char.IsDigit(curr) && !char.IsDigit(next) && !isLast)
                    buffer += "_";
            }
            return buffer;
        }
    }
