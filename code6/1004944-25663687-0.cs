	namespace ReflectionsTest
	{
		public partial class MainForm : Form
		{
			public MainForm()
			{
				InitializeComponent();
			}
            
            //Events excluded
            
			private void ExecuteCommand(string command)
			{
				
					string cmd = "";
					cmd += @"using System;
							 using System.Collections.Generic;
							 using System.ComponentModel;
							 using System.Drawing;
							 using System.Text;
							 using System.Windows.Forms;
                             using System.Linq;
							 using Microsoft.CSharp;
							 using System.Reflection;
							 using ReflectionsTest;";
                             // i included a using statement for every namespace i want to adress direct
					cmd += @"namespace ReflectionConsole 
							{ 
								public class RuntimeExecution 
								{ 
									public static void Main(MainForm parent, TextBox output, FieldInfo[] privateFields) 
									{
										try {";
                           //the code in a trycatch because i can send every error to a specific output defined as output parameter
					cmd += command;
					cmd += "}catch (Exception ex) { if(output != null){" +
							"output.Text += ex.Message + \"\\n\\r\";"
							+"}else{MessageBox.Show(ex.Message);}}}}}";
					try {
						ExecuteCSharp(cmd);
					}
					catch (Exception ex) {
						textBox2.Text += ex.Message + "\n\r";
					}
				}
			
			private void ExecuteCSharp(string code)
			{
				CSharpCodeProvider provider = new CSharpCodeProvider();
				CompilerParameters parameters = new CompilerParameters();
				List<AssemblyName> assemblys = (Assembly.GetExecutingAssembly().GetReferencedAssemblies()).ToList<AssemblyName>();
				foreach (var item in assemblys) {
					parameters.ReferencedAssemblies.Add(item.Name + ".dll");
				}
				string t = Assembly.GetExecutingAssembly().GetName().Name;
				parameters.ReferencedAssemblies.Add(t + ".exe");
                //Here you have to reference every assembly the console wants access
				parameters.GenerateInMemory = true;
				parameters.GenerateExecutable = false;
				CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
				if (results.Errors.HasErrors) {
					StringBuilder sb = new StringBuilder();
					foreach (CompilerError error in results.Errors) {
						sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
						}
					throw new InvalidOperationException(sb.ToString());
				}
				else {
					Assembly assembly = results.CompiledAssembly;
					Type program = assembly.GetType("ReflectionConsole.RuntimeExecution");
					MethodInfo main = program.GetMethod("Main");
					FieldInfo[] fields = this.GetType().GetFields(
							 BindingFlags.NonPublic |
							 BindingFlags.Instance);
                    //if everything is correct start the method with some arguments:
                    // containing class, output, private fields of the containing class for easier access
					main.Invoke(null, new object[]{this, textBox2, fields});
     			}
			}
		}
	}
