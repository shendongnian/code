            string nspace = "CompanyAdministration.data.Models";
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace && t.Name[0] != '<' && t.Name.Substring(0, 2) != "BOX" && t.Name != "CAContext"
                    select t;
            foreach (Type t in q)
            {
                    try
                    {
                        MethodInfo method = modelBuilder.GetType().GetMethod("Entity");
                        method = method.MakeGenericMethod(new Type[] { t });
                        method.Invoke(modelBuilder, null);
                    }
                    catch
                    {
                    }
            }
            base.OnModelCreating(modelBuilder);
