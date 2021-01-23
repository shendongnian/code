    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Reflection.Emit;
    
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                int a;
                string s = "";
                while ((a = int.Parse(Console.ReadLine())) != 0)
                {
    
    
                    var t = DynamicButton.generateClass(a);
    
                    ((IExternalCommand)t.GetConstructor(new Type[0]).Invoke(new object[0])).Execute(null, ref s, null);
                }
            }
        }
    
        public interface IExternalCommand
        {
            Result Execute(ExternalCommandData revit, ref string message, ElementSet elements);
        }
    
        public class DynamicButton
        {
            // I would like to use a function like this to generate the class during runtime, presumably using TypeBuilder:
            public static Type generateClass(int id)
            {
                // ... Code which would generate a class with the name "GeneratedClass" with the 'id' parameter appended at the end
                // ... The class implements IExternalCommand
                // ... The class has an Execute function with the parameters listed in the example, which returns a call to the Execute function in DynamicButton
                //      along with the added integer 'id' parameter at the end
    
                AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
                AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.RunAndSave);
    
                // For a single-module assembly, the module name is usually 
                // the assembly name plus an extension.
                ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
    
                // Create class which extends Object and implements IExternalCommand
                var implements = new Type[] {typeof(IExternalCommand)};
                TypeBuilder tb = mb.DefineType("GeneratedClass" + id, TypeAttributes.Public, typeof(Object), implements);
    
    
                // Create 'Execute' function sig
                Type[] paramList = {typeof(ExternalCommandData), Type.GetType("System.String&"), typeof(ElementSet)};
                MethodBuilder mbExecute = tb.DefineMethod("Execute", MethodAttributes.Public | MethodAttributes.Virtual, typeof(Result), paramList);
    
                // Create 'Execute' function body
                ILGenerator ilGen = mbExecute.GetILGenerator();
    
                ilGen.Emit(OpCodes.Nop);
                ilGen.Emit(OpCodes.Ldarg_1);
                ilGen.Emit(OpCodes.Ldarg_2);
                ilGen.Emit(OpCodes.Ldarg_3);
    
                ilGen.Emit(OpCodes.Ldc_I4_S, id);
    
                Type[] paramListWID = { typeof(ExternalCommandData), Type.GetType("System.String&"), typeof(ElementSet), typeof(int) };
                ilGen.EmitCall(OpCodes.Call, typeof(DynamicButton).GetMethod("Execute"), paramListWID);
    
    
                ilGen.Emit(OpCodes.Ret);
    
    
             
                tb.DefineMethodOverride(mbExecute, typeof(IExternalCommand).GetMethod("Execute"));
                return tb.CreateType();
            }
    
            public static Result Execute(ExternalCommandData revit, ref string message, ElementSet elements, int id)
            {
                Console.WriteLine("About {0}", "ID of the class that called us: " + id);
                return Result.Succeeded;
            }
        }
    
        public enum Result
        {
            Succeeded
        }
    
        public class ExternalCommandData { }
        public class ElementSet { }
        // =================================================================== //
    }
