    public class CredentialConfigurationElement : ConfigurationElement
    {
        #region Properties
        [ConfigurationProperty("userName", DefaultValue="", IsRequired=true)]
        public string UserName
        {
            get { return (string)this["userName"];}
            set { this["userName"] = value; }
        }
        [ConfigurationProperty("password", DefaultValue = "", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }
        #endregion
        #region Explicit Operators
        public static implicit operator NetworkCredential(CredentialConfigurationElement value)
        {
            return new NetworkCredential(value.UserName, value.Password);
        }
        public static implicit operator CredentialConfigurationElement(NetworkCredential value)
        {
            return new CredentialConfigurationElement() { UserName = value.UserName, Password = value.Password };
        }
        #endregion
    }
