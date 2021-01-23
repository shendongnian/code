    using System;
    using System.Linq;
    using System.Reflection;
    using Dapper;
    namespace DapperTestProj.DapperAttributeMapper
    {
        public static class TypeMapper
        {
            public static void Initialize(string @namespace)
            {
                var types = from type in Assembly.GetExecutingAssembly().GetTypes()
                            where type.IsClass && type.Namespace == @namespace
                            select type;
                types.ToList().ForEach(type =>
                {
                    var mapper = (SqlMapper.ITypeMap)Activator
                        .CreateInstance(typeof(ColumnAttributeTypeMapper<>)
                                        .MakeGenericType(type));
                    SqlMapper.SetTypeMap(type, mapper);
                });
            }
        }
    }
