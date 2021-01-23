    public class RuntimeContainerBuilder
    {
        public static object Evaluate(ContainerBuilder builder, Type controller, Type repoInterface, Type repoClass, Assembly assembly)
        {
            CSharpCodeProvider c = new CSharpCodeProvider();
            ICodeCompiler icc = c.CreateCompiler();
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add(AssemblyDirectory + "\\System.Web.Http.dll");
            cp.ReferencedAssemblies.Add(AssemblyDirectory + "\\Autofac.dll");
            cp.ReferencedAssemblies.Add(AssemblyDirectory + "\\Autofac.Integration.WebApi.dll");
            cp.ReferencedAssemblies.Add(@"E:\MainTrunk2\LeadGenFramework\trunk\LeadGenFramework.Web.Api\LeadGenFramework.Web.Api.Controller.TitleLoan\bin\LeadGenFramework.Web.Api.TitleLoan.dll");
            cp.CompilerOptions = "/t:library";
            cp.GenerateInMemory = true;
            StringBuilder sb = new StringBuilder("");
            sb.Append("using System;\n");
            sb.Append("using Autofac;\n");
            sb.Append("using System.Web.Http;\n");
            sb.Append("using System.Web.Http.Controllers;\n");
            sb.Append("using Autofac.Integration.WebApi;\n");
            sb.Append(string.Format("using {0};\n", assembly.ManifestModule.Name.Replace(".dll","")));
            
            sb.Append("namespace LeadGenFramework.Web.Api{ \n");
            sb.Append("public class DynamicBuild{ \n");
            sb.Append("public ContainerBuilder Build(ContainerBuilder obj){\n");
            sb.Append(string.Format("obj.RegisterApiControllers(typeof({0}).Assembly).PropertiesAutowired();\n",controller.Name));
            sb.Append(string.Format("obj.RegisterInstance<{0}>(new {1}());\n", repoInterface.Name, repoClass.Name));
            sb.Append("return obj; \n");
            sb.Append("} \n");
            sb.Append("} \n");
            sb.Append("}\n");
            string s1 = sb.ToString();
            CompilerResults cr = icc.CompileAssemblyFromSource(cp, s1);
            if (cr.Errors.Count > 0)
            {
                //Factory.LogManager.MainProcessLogger.Info(string.Format("DynamicFormatScriptEngine:Evaluate(): Error: {0}, Code: {1}", cr.Errors[0], s1));
                return null;
            }
            Assembly a = cr.CompiledAssembly;
            object o = a.CreateInstance("LeadGenFramework.Web.Api.DynamicBuild");
            Type t = o.GetType();
            MethodInfo mi = t.GetMethod("Build");
            object s = mi.Invoke(o,new object[]{builder});
            return s;
        }
