    namespace FolderConfigSection
    {
      using System.Configuration;
      public class LocationConfig : ConfigurationSection
      {
        // Change the property type to FolderCollection, and
        // change the property name to `Folders` for clarity
        [ConfigurationProperty("folders")]
        public FolderCollection Folders
        {
          
          get { return base["folders"] as FolderCollection; }
          // the setter property isn't really needed here
          // set { base["folders"] = value; }
        }
      }
      public class FolderCollection : ConfigurationElementCollection
      {
        protected override ConfigurationElement CreateNewElement()
        {
          return new FolderElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
          return ((FolderElement)element).Environment;
        }
        // indexer
        public FolderElement this[int index]
        {
          get { return BaseGet(index) as FolderElement; }      
        }
      }
      public class FolderElement : ConfigurationElement
      {
        [ConfigurationProperty("folder", IsRequired = true)]
        public string Environment
        {
          get { return (string)this["folder"]; }
          set { this["folder"] = value; }
        }
      }
    }
