    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.IO;
    
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void submitButton_Click(object sender, EventArgs e)
        {
            if (codeTextArea.Text != null)
            {
                
                // Build a class and assembly:
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateExecutable = true;
                string codeString = @"using System; using System.IO; namespace StudyGroup { public class WebProgram {  private String _outputString = ""output""; public static void Main() {  ";
                codeString += codeTextArea.Text;
                codeString += @" } } }";
                CompilerResults results = provider.CompileAssemblyFromSource(parameters, codeString);
                var path = results.PathToAssembly;
    
                // Output:
    
                string outputString = "";
    
                // Error handling:
    
                if (results.Errors.HasErrors)
                {
                    outputString += "You haz errors:\n";
                    foreach (CompilerError error in results.Errors)
                    {
                        outputString += error.ErrorText;
                        outputString += "\n";
                    }
                    //throw new InvalidOperationException(outputString);
                    outputTextArea.Text = outputString;
                }
                else
                {
    
                    // Instantiate an instance and invoke Main method:
    
                    //var assembly = Assembly.LoadFrom(path);
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.FileName = path;
                    
                    process.Start();
    
                    var moreOutput = process.StandardOutput.ReadToEnd();
                    
                    outputString += moreOutput;
    
                    // Output:
    
                    Console.WriteLine(outputString);
                    Console.ReadLine();
                    outputTextArea.Text = outputString;
                }
            }
        }
    }
