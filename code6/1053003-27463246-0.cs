	public static unsafe Type GetTypeFromFieldSignature(byte[] signature, Type declaringType = null)
	{
		declaringType = declaringType ?? typeof(object);
		Type sigtype = typeof(Type).Module.GetType("System.Signature");
		Type rtype = typeof(Type).Module.GetType("System.RuntimeType");
		var ctor = sigtype.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new[]{typeof(void*), typeof(int), rtype}, null);
		fixed(byte* ptr = signature)
		{
			object sigobj = ctor.Invoke(new object[]{(IntPtr)ptr, signature.Length, declaringType});
			return (Type)sigtype.InvokeMember("FieldType", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty, null, sigobj, null);
		}
	}
