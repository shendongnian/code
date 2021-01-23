        <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
          <configSections>
            <section name="DBConfiguration" type="CSRAssistant.DBConfigurationSection, CSRAssistant"/>
            <section name="LoginConfiguration" type="CSRAssistant.LoginConfigurationSection, CSRAssistant"/>
          </configSections>
        
          <DBConfiguration>
            <add servername="192.168.88.2\bbareman" dbname="BBAJobBoardForGB" userid="sa" password="8B@R5m@n" countrycode="GBR" />
            <add servername="192.168.1.2\bbareman" dbname="BBAJobBoardForUS" userid="sa" password="8B@R5m@n" countrycode="USA" />
            <add servername="192.168.2.2\bbareman" dbname="BBAJobBoardForDE" userid="sa" password="8B@R5m@n" countrycode="DEU" />
            <add servername="192.168.77.10\bbareman" dbname="BBAJobBoardForFR" userid="sa" password="8B@R5m@n" countrycode="FRA" />
            <add servername="192.168.3.2\bbareman" dbname="BBAJobBoardForIT" userid="sa" password="8B@R5m@n" countrycode="ITA" />
            <add servername="192.168.4.2\bbareman" dbname="BBAJobBoardForCA" userid="sa" password="8B@R5m@n" countrycode="CAD" />
            <add servername="192.168.55.10\bbareman" dbname="BBAJobBoardForES" userid="sa" password="8B@R5m@n" countrycode="ESP" />
          </DBConfiguration>
        
          <LoginConfiguration>
            <add ID="1" UserName="suanguite" Pwd="gguite" Country="GBR"/>
            <add ID="2" UserName="sujoy" Pwd="sujoyUS"  Country="USA"/>
            <add ID="3" UserName="sujoy" Pwd="sujoyCA"  Country="CAD"/>
            <add ID="4" UserName="pjasu" Pwd="pjasuDE"  Country="DEU"/>
            <add ID="5" UserName="kankana" Pwd="kankana123"  Country="ITA"/>
            <add ID="6" UserName="test" Pwd="test"  Country="IND"/>
            <add ID="7" UserName="biswajit" Pwd="biswajitES"  Country="ESP"/>
            <add ID="8" UserName="suparna" Pwd="suparna"  Country="CAD"/>
            <add ID="9" UserName="razi" Pwd="raziFR"  Country="FRA"/>
            <add ID="10" UserName="tridip" Pwd="tridip"  Country="GBR"/>
            <add ID="11" UserName="tridip" Pwd="tridip"  Country="ESP"/>
            <add ID="12" UserName="tridip" Pwd="tridip"  Country="FRA"/>
          </LoginConfiguration>
          <appSettings>
            <add key="MailID" value="tridip@bba-reman.com" />
          </appSettings>
        
          <startup useLegacyV2RuntimeActivationPolicy="true">
            <supportedRuntime version="v4.0"/>
            <requiredRuntime version="v4.0.20506"/>
          </startup>
        
        </configuration>
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    
    namespace CSRAssistant
    {
        public class DBConfigurationSection : ConfigurationSection
        {
            //[ConfigurationProperty("Items")]
            //public ItemsCollection Items
            //{
            //    get { return ((ItemsCollection)(base["Items"])); }
            //}
    
            [ConfigurationProperty("", IsDefaultCollection = true)]
            public ItemsCollection Items
            {
                get
                {
                    return ((ItemsCollection)(base[""]));
                }
            }
        }
    
        [ConfigurationCollection(typeof(ItemsElement))]
        public class ItemsCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new ItemsElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((ItemsElement)(element)).CountryCode;
            }
    
            public ItemsElement this[int idx]
            {
                get
                {
                    return (ItemsElement)BaseGet(idx);
                }
            }
        }
    
        public class ItemsElement : ConfigurationElement
        {
            [ConfigurationProperty("servername", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string ServerName
            {
                get
                {
                    return ((string)(base["servername"]));
                }
                set
                {
                    base["servername"] = value;
                }
            }
    
            [ConfigurationProperty("dbname", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string DBName
            {
                get
                {
                    return ((string)(base["dbname"]));
                }
                set
                {
                    base["dbname"] = value;
                }
            }
    
            [ConfigurationProperty("userid", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string UserID
            {
                get
                {
                    return ((string)(base["userid"]));
                }
                set
                {
                    base["userid"] = value;
                }
            }
    
            [ConfigurationProperty("password", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string Password
            {
                get
                {
                    return ((string)(base["password"]));
                }
                set
                {
                    base["password"] = value;
                }
            }
    
            [ConfigurationProperty("countrycode", DefaultValue = "", IsKey = true, IsRequired = true)]
            public string CountryCode
            {
                get
                {
                    return ((string)(base["countrycode"]));
                }
                set
                {
                    base["countrycode"] = value;
                }
            }
        }
    
    
    }
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    
    namespace CSRAssistant
    {
        //****login config
    
        public class LoginConfigurationSection : ConfigurationSection
        {
            //[ConfigurationProperty("Items")]
            //public ItemsCollection Items
            //{
            //    get { return ((ItemsCollection)(base["Items"])); }
            //}
    
            [ConfigurationProperty("", IsDefaultCollection = true)]
            public LoginCollection Items
            {
                get
                {
                    return ((LoginCollection)(base[""]));
                }
            }
        }
    
        [ConfigurationCollection(typeof(LoginElement))]
        public class LoginCollection : ConfigurationElementCollection
        {
            protected override ConfigurationElement CreateNewElement()
            {
                return new LoginElement();
            }
    
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((LoginElement)(element)).ID;
            }
    
            public LoginElement this[int idx]
            {
                get
                {
                    return (LoginElement)BaseGet(idx);
                }
            }
        }
        public class LoginElement : ConfigurationElement
        {
            [ConfigurationProperty("UserName", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string UserName
            {
                get
                {
                    return ((string)(base["UserName"]));
                }
                set
                {
                    base["UserName"] = value;
                }
            }
    
            [ConfigurationProperty("Pwd", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string Pwd
            {
                get
                {
                    return ((string)(base["Pwd"]));
                }
                set
                {
                    base["Pwd"] = value;
                }
            }
    
            [ConfigurationProperty("Country", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string Country
            {
                get
                {
                    return ((string)(base["Country"]));
                }
                set
                {
                    base["Country"] = value;
                }
            }
    
            [ConfigurationProperty("ID", DefaultValue = "", IsKey = false, IsRequired = false)]
            public string ID
            {
                get
                {
                    return ((string)(base["ID"]));
                }
                set
                {
                    base["ID"] = value;
                }
            }
        }
    }
