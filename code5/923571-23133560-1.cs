    public static List<string> GetFieldsUsedInDocument(Document document)
            {
                var fields = new List<string>();
    
                foreach (MailMergeField fld in document.MailMerge.Fields)
                {
                    if (fld.Code != null)
                    {
                        fields.Add(fld.Code.Text.ToUpper());
                    }
                }
                return fields;
            }
