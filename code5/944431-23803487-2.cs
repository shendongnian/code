     if (int.TryParse(sms.Sms_Nom.ToCharArray()
                 .Where(c => !Char.IsWhiteSpace(c))
                 .Select(c => c.ToString())
                 .Aggregate((a, b) => a + b), out value))
                {
                    ListSms.Add(value);
                }
