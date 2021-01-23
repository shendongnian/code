    public string GetCustomFieldValue(string custFieldName)
        {
            Collection attrValues = requirement.AttributeValues; //requirement is a Caliber RM 'Requirement'
            for (var i = 0; i < attrValues.Count; i++)
            {
                AttributeValue av = (AttributeValue) attrValues[i];
                if(av.Attribute.Name.Equals(custFieldName))
                {
                    if (attrValues[i] is UDAListValue)
                    {
                        UDAListValue values = (UDAListValue)attrValues[i];
                        return values.SelectedValue.ToString();
                    }
                }
            }
            return "";
        }
