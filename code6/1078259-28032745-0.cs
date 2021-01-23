        public string PhoneNumbers1
        {
            get
            {
                if ((PhoneNumbers != null) && (PhoneNumbers.Length > 0))
                {
                    return PhoneNumbers[0].Number;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
