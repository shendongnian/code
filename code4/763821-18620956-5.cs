	static void Main(string[] args)
		{
			var mystring = getValorDaClasse("NFSe.Classes.Models.Classes.NFSeWeb.Service");
		}
		public static string getValorDaClasse(object valor)
		{
			if (valor.ToString().Contains("NFSe.Classes.Models.Classes"))
			{
				Type myType = Type.GetType(valor.ToString());
				object myObj = Activator.CreateInstance(myType);
				//Invoking a non-static method (How to invoke a non static method??)
				return (string)myType.InvokeMember("getKey", BindingFlags.InvokeMethod|BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance, null, myObj, null);
			}
			else
				return valor.ToString();
		}
