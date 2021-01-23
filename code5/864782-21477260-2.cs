    using System;
    
    namespace MyProject.Filters
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class SortableAttribute : Attribute
        {
            public SortableAttribute(string by = "")
            {
                this.By = by;
            }
    
            public string By { get; private set; }
        }
    }
