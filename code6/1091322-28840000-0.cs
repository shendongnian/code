    using System.ComponentModel;
    using System.Resources;
    namespace SCC.Case.Entities
    {
        /// <summary>
        /// Provides a class attribute that lets you specify the localizable string for the entity class
        /// </summary>
        class DisplayNameForClassAttribute : DisplayNameAttribute
        {
            public string Name { get; set; }
            public override string DisplayName
            {
                get
                {
                    ResourceManager resourceManager = new ResourceManager("SCC.Case.Entities.DisplayNames", typeof(DisplayNameForClassAttribute).Assembly);
                    return resourceManager.GetString(this.Name);
                }
            }
        }
    }
