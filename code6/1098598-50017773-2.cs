    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using YamlDotNet.Core.Events;
    using YamlDotNet.Serialization;
    public class ExpandoNodeTypeResolver : INodeTypeResolver
    {
        public bool Resolve(NodeEvent nodeEvent, ref Type currentType)
        {
            if (currentType == typeof(object))
            {
                if (nodeEvent is SequenceStart)
                {
                    currentType = typeof(List<object>);
                    return true;
                }
                if (nodeEvent is MappingStart)
                {
                    currentType = typeof(ExpandoObject);
                    return true;
                }
            }
            return false;
        }
    }
