    using System;
    using System.Activities;
    using System.Activities.Expressions;
    using System.Activities.XamlIntegration;
    using System.Linq;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Activation;
    namespace ExpenseReporting {
       public class CSharpWorkflowServiceHostFactory : WorkflowServiceHostFactory {
          protected override WorkflowServiceHost CreateWorkflowServiceHost(WorkflowService service, Uri[] baseAddresses) {
             CompileExpressions(service.Body);
             return base.CreateWorkflowServiceHost(service, baseAddresses);
          }
          static void CompileExpressions(Activity activity) {
             // activityName is the Namespace.Type of the activity that contains the C# expressions.
             var activityName = activity.GetType().ToString();
             // Split activityName into Namespace and Type.Append _CompiledExpressionRoot to the type name
             // to represent the new type that represents the compiled expressions.
             // Take everything after the last . for the type name.
             var activityType = activityName.Split('.').Last() + "_CompiledExpressionRoot";
             // Take everything before the last . for the namespace.
             var activityNamespace = string.Join(".", activityName.Split('.').Reverse().Skip(1).Reverse());
             // Create a TextExpressionCompilerSettings.
             var settings = new TextExpressionCompilerSettings {
                Activity = activity,
                Language = "C#",
                ActivityName = activityType,
                ActivityNamespace = activityNamespace,
                RootNamespace = null,
                GenerateAsPartialClass = false,
                AlwaysGenerateSource = true,
                ForImplementation = false
             };
             // Compile the C# expression.
             var results =
                 new TextExpressionCompiler(settings).Compile();
             // Any compilation errors are contained in the CompilerMessages.
             if (results.HasErrors) { throw new Exception("Compilation failed."); }
             // Create an instance of the new compiled expression type.
             var compiledExpressionRoot = Activator.CreateInstance(results.ResultType, new object[] { activity }) as ICompiledExpressionRoot;
             // Attach it to the activity.
             CompiledExpressionInvoker.SetCompiledExpressionRoot( activity, compiledExpressionRoot);
          }
       }
    }
