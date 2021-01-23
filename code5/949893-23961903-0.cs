        public static GenericMessage BytesToClass(byte[] Source, ClassType MyType)
        {
            // Gets the Type we want to convert the Source byte array to from the Enum 
            Type _targetType = typeof(Program).GetNestedType(MyType.ToString());
            // Gets the generic convertion method, note we have to give it the exact parameters as there are 2 methods with the same name
            var _convMethod = typeof(Program).GetMethod("BytesToClass", new Type[] { typeof(byte[]) });
            // Invoke the generic method, setting T as _targetType
            var result = _convMethod.MakeGenericMethod(new Type[] { _targetType }).Invoke(null, new object[] { Source });
            return (GenericMessage)result;
        }
