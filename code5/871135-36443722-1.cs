     public static void GetMenuXml()
            {
           var projectName = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            Assembly asm = Assembly.GetAssembly(typeof(MvcApplication));
            var model = asm.GetTypes().
                SelectMany(t => t.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(d => d.ReturnType.Name == "ActionResult").Select(n => new MyMenuModel()
                {
                    Controller = n.DeclaringType?.Name.Replace("Controller", ""),
                    Action = n.Name,
                    ReturnType = n.ReturnType.Name,
                    Attributes = string.Join(",", n.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
                    Area = n.DeclaringType.Namespace.ToString().Replace(projectName + ".", "").Replace("Areas.", "").Replace(".Controllers", "").Replace("Controllers", "")
                });
            SaveData(model.ToList());
        }
