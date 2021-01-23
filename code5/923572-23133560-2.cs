     public static List<string> GetMergeFields(List<string> allFields)
            {
                var merges = new List<string>();
    
                foreach (var field in allFields)
                {
                    var isNestedField = false;
                    foreach (var fieldChar in field)
                    {
                        int charCode = fieldChar;
                        if (charCode == 19 || charCode == 21)
                        {
                            isNestedField = true;
                            break;
                        }
                    }
                    if (!isNestedField)
                    {
                        var fieldCode = field;
                        if (fieldCode.Contains("MERGEFIELD"))
                        {
                            var fieldName = fieldCode.Replace("MERGEFIELD", string.Empty).Replace('"', ' ').Trim();
                            var charsToGet = fieldName.IndexOf(" ");
                            if (charsToGet < 0)
                                charsToGet = fieldName.IndexOf(@"\");
    
                            charsToGet = charsToGet > 0 ? charsToGet : fieldName.Length;
    
                            fieldName = fieldName.Substring(0, charsToGet);
    
                            if (!merges.Contains(fieldName))
                            {
                                merges.Add(fieldName);
                            }
                        }
                    }
                }
                return merges;
            }
