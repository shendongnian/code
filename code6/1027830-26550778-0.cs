         /// <summary>
        /// POCOs that have XYZ Attribute of Type  and NOT abstract and not complex
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetBosDirDBPocoList() {
            var result = new List<Type>();
            // so get all the Class from teh assembly that public non abstract and not complex
            foreach (var t in Assembly.GetExecutingAssembly().GetTypes()
                                      .Where(t => t.BaseType != null
                                                  && t.IsClass
                                                  && t.IsPublic
                                                  && !t.IsAbstract
                                                  && !t.IsComplexType()
                                                  && t.GetMyAttribute() != null)) {
            
                  
                    result.Add(t);
                }
            }
            return result;
        }
         public static GetMyAttribute(this Type T) {
            var myAttr= T.GetCustomAttributes(true)
                          .Where(attribute => attribute.GetType()
                          .Name == "XYZAttr").Cast<BosDir>().FirstOrDefault();
            return myAttr;
        }
