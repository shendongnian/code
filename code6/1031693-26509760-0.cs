    // user defined function: public double UserFunc(double x, double y, string str)
    public static object UserDefinedFunc(string UserCode, object[] Parameters) 
    {
    	CSharpCodeProvider c = new CSharpCodeProvider();
    	ICodeCompiler icc = c.CreateCompiler();
    	CompilerParameters cp = new CompilerParameters();
    
    	cp.ReferencedAssemblies.Add("system.dll");
    	cp.CompilerOptions = "/t:library";
    	cp.GenerateInMemory = true;
    
    	StringBuilder sb = new StringBuilder("");
    	sb.Append("using System;\n");
    	sb.Append("namespace CSCodeEvaler{ \n");
    	sb.Append("public class CSCodeEvaler{ \n");
    
    	// start function envelope
    	sb.Append("public double UserFunc(double x, double y, string str){ \n");
    	sb.Append("double z; \n");
    
    	// enveloped user code
    	sb.Append(UserCode + "\n");
    
    	// close function envelope
    	sb.Append("return z; \n");
    	sb.Append("} \n");
    
    	sb.Append("} \n");
    	sb.Append("}\n");
    
    	CompilerResults cr = icc.CompileAssemblyFromSource(cp, sb.ToString());
    	if (cr.Errors.Count > 0)
    	{
    		MessageBox.Show("ERROR: " + cr.Errors[0].ErrorText,
    		   "Error evaluating cs code", MessageBoxButtons.OK,
    		   MessageBoxIcon.Error);
    		return null;
    	}
    
    	System.Reflection.Assembly a = cr.CompiledAssembly;
    	object o = a.CreateInstance("CSCodeEvaler.CSCodeEvaler");
    
    	Type t = o.GetType();
    	MethodInfo mi = t.GetMethod("UserFunc");
    
    	object s = mi.Invoke(o, Parameters);
    	return s;
    }
