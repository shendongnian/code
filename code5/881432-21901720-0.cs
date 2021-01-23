    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        public sealed class UsersConfigMapSection : ConfigurationSection
        {
            private static UsersConfigMapSection config = ConfigurationManager.GetSection("Users") as UsersConfigMapSection;
    
            public static UsersConfigMapSection Config
            {
                get
                {
                    return config;
                }
            }
    
            [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
            private UsersConfigMapConfigElements Settings
            {
                get { return (UsersConfigMapConfigElements)this[""]; }
                set { this[""] = value; }
            }
    
            public IEnumerable<UsersConfigMapConfigElement> SettingsList
            {
                get { return this.Settings.Cast<UsersConfigMapConfigElement>(); }
            }
        }
    
        public sealed class UsersConfigMapConfigElements : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new UsersConfigMapConfigElement();
            }
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((UsersConfigMapConfigElement)element).Username;
            }
        }
    
        public sealed class UsersConfigMapConfigElement : ConfigurationElement
        {
            [ConfigurationProperty("username", IsKey = true, IsRequired = true)]
            public string Username
            {
                get { return (string)base["username"]; }
                set { base["username"] = value; }
            }
    
            [ConfigurationProperty("password", IsRequired = true)]
            public string Password
            {
                get { return (string)base["password"]; }
                set { base["password"] = value; }
            }
    
            [ConfigurationProperty("domain", IsRequired = true)]
            public string Domain
            {
                get { return (string)base["domain"]; }
                set { base["domain"] = value; }
            }
        }
    }
    
