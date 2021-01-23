    class binder : SerializationBinder
	{
		Type[] types;
		public binder(Type[] Types)
		{
			types = Types;
		}
		public override Type BindToType(string assemblyName, string typeName)
		{
			if(assemblyName == "RaspElements")
			{
				var type = types.Where(t => t.Name == typeName).FirstOrDefault();
				if (type != null)
					return type;
			
			}
			return Type.GetType(typeName + ", " + assemblyName);
		}
	}
