    using System;
    namespace DapperTestProj.DapperAttributeMapper //Maybe a better namespace here
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
        public class ColumnAttribute : Attribute
        {
            public string Name { get; set; }
            public ColumnAttribute(string name)
            {
                Name = name;
            }
        }
    }
