    [DirectoryProperty("facsimileTelephoneNumber")]
        public string FaxNumber
        {
            get
            {
                if (ExtensionGet("facsimileTelephoneNumber").Length != 1)
                    return null;
                return (string)ExtensionGet("facsimileTelephoneNumber")[0];
            }
            set
            {
                ExtensionSet("facsimileTelephoneNumber", string.IsNullOrEmpty(value) ? new string[1] {null} : new string[1] {value});
            }
        }
