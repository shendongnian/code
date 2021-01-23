    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WebBrowserApp
    {
    	// http://stackoverflow.com/a/19067386/1768303
    	public partial class MainForm : Form
    	{
    		WebBrowser wb;
    
    		public MainForm()
    		{
    			InitializeComponent();
    			
    			this.wb = new WebBrowser();
    			this.wb.Dock = DockStyle.Fill;
    			this.Controls.Add(this.wb);
    			this.wb.Visible = true;
    
    			var dynamicComponent = new DynamicComponent();
    			// make dynamicComponent available to VBScript
    			this.wb.ObjectForScripting = dynamicComponent;
    
    			// add a dynamic mathod
    			dynamicComponent.SetMethod("Convert", new Func<int, string>((a) =>			
    			{
    				MessageBox.Show("Convert called: " + a.ToString());
    				return a.ToString();
    			}));
    
    			this.Load += (s, e) =>
    			{
    				this.wb.Navigate("http://localhost:81/vbtest.html");
    			};
    		}
    	}
    
    	#region DynamicComponent
    	[ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    	public class DynamicComponent : System.Reflection.IReflect
    	{
    		readonly Dictionary<string, Delegate> _methods = new Dictionary<string, Delegate>();
    
    		static Exception NotImplemented()
    		{
    			var method = new StackTrace(true).GetFrame(1).GetMethod().Name;
    			Debug.Assert(false, method);
    			return new NotImplementedException(method);
    		}
    
    		public void SetMethod(string name, Delegate value)
    		{
    			_methods[name] = value;
    		}
    
    		#region IReflect
    		// IReflect
    
    		public FieldInfo GetField(string name, BindingFlags bindingAttr)
    		{
    			throw NotImplemented();
    		}
    
    		public FieldInfo[] GetFields(BindingFlags bindingAttr)
    		{
    			return new FieldInfo[0];
    		}
    
    		public MemberInfo[] GetMember(string name, BindingFlags bindingAttr)
    		{
    			throw NotImplemented();
    		}
    
    		public MemberInfo[] GetMembers(BindingFlags bindingAttr)
    		{
    			return new MemberInfo[0];
    		}
    
    		public MethodInfo GetMethod(string name, BindingFlags bindingAttr)
    		{
    			throw NotImplemented();
    		}
    
    		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
    		{
    			throw NotImplemented();
    		}
    
    		public MethodInfo[] GetMethods(BindingFlags bindingAttr)
    		{
    			return _methods.Keys.Select(name => new DynamicMethodInfo(name, _methods[name].Method)).ToArray();
    		}
    
    		public PropertyInfo[] GetProperties(BindingFlags bindingAttr)
    		{
    			return new PropertyInfo[0];
    		}
    
    		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
    		{
    			throw NotImplemented();
    		}
    
    		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr)
    		{
    			throw NotImplemented();
    		}
    
    		public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters)
    		{
    			if (target == this && invokeAttr.HasFlag(BindingFlags.InvokeMethod))
    			{
    				Delegate method;
    				if (!_methods.TryGetValue(name, out method))
    					throw new MissingMethodException();
    				return method.DynamicInvoke(args);
    			}
    			throw new ArgumentException();
    		}
    
    		public Type UnderlyingSystemType
    		{
    			get { throw NotImplemented(); }
    		}
    		#endregion
    
    		#region DynamicMethodInfo
    
    		// DynamicPropertyInfo
    		protected class DynamicMethodInfo : System.Reflection.MethodInfo
    		{
    			string _name;
    			MethodInfo _mi;
    
    			public DynamicMethodInfo(string name, MethodInfo mi)
    				: base()
    			{
    				_name = name;
    				_mi = mi;
    			}
    
    			public override MethodInfo GetBaseDefinition()
    			{
    				return _mi.GetBaseDefinition();
    			}
    
    			public override ICustomAttributeProvider ReturnTypeCustomAttributes
    			{
    				get { return _mi.ReturnTypeCustomAttributes; }
    			}
    
    			public override MethodAttributes Attributes
    			{
    				get { return _mi.Attributes; }
    			}
    
    			public override MethodImplAttributes GetMethodImplementationFlags()
    			{
    				return _mi.GetMethodImplementationFlags();
    			}
    
    			public override ParameterInfo[] GetParameters()
    			{
    				return _mi.GetParameters();
    			}
    
    			public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, System.Globalization.CultureInfo culture)
    			{
    				return _mi.Invoke(obj, invokeAttr, binder, parameters, culture);
    			}
    
    			public override RuntimeMethodHandle MethodHandle
    			{
    				get { return _mi.MethodHandle; }
    			}
    
    			public override Type DeclaringType
    			{
    				get { return _mi.DeclaringType; }
    			}
    
    			public override object[] GetCustomAttributes(Type attributeType, bool inherit)
    			{
    				return _mi.GetCustomAttributes(attributeType, inherit);
    			}
    
    			public override object[] GetCustomAttributes(bool inherit)
    			{
    				return _mi.GetCustomAttributes(inherit);
    			}
    
    			public override bool IsDefined(Type attributeType, bool inherit)
    			{
    				return _mi.IsDefined(attributeType, inherit);
    			}
    
    			public override string Name
    			{
    				get { return _name; }
    			}
    
    			public override Type ReflectedType
    			{
    				get { return _mi.ReflectedType; }
    			}
    		}
    
    		#endregion
    	}
    	#endregion
    }
