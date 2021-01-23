      static void Main(string[] args)
        {
            var typeBuilder = CreateTypeBuilder();
            AddStaticMethodAsAProperty(typeBuilder, "StaticPublic", Return1);
            AddStaticMethodAsAProperty(typeBuilder, "StaticPrivate", Return2);
            AddStaticMethodAsAProperty(typeBuilder, "Lambda", () => 3);
            var newType = typeBuilder.CreateType();
            dynamic newObject = Activator.CreateInstance(newType);
            foreach (var onNewObjectCreated in _onNewObjectCreated)
            {
                onNewObjectCreated(newObject);
            }
            var resultFromStatic = newObject.StaticPublic; //Ok 1
            var resultFromStaticPrivate = newObject.StaticPrivate; //Ok 2
            var resultFromLambda = newObject.Lambda; //Ok 3
        }
        private static List<Action<object>> _onNewObjectCreated = new List<Action<object>>();
        public static void AddStaticMethodAsAProperty<T>(TypeBuilder typeBuilder, string propertyName, Func<T> valueGetter)
        {
            var propertyType = valueGetter.Method.ReturnType;
            var delegateFieldBuilder = typeBuilder.DefineField(string.Format("_backingDelegate{0}", propertyName), valueGetter.GetType(), FieldAttributes.Private);
            var getMethod = typeBuilder.DefineMethod(string.Format("get_{0}", propertyName), MethodAttributes.Public | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            Action<object> setDelegateFieldAction = newlyCreatedObject => { newlyCreatedObject.GetType().GetField(delegateFieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Instance).SetValue(newlyCreatedObject, valueGetter); };
            _onNewObjectCreated.Add(setDelegateFieldAction);
            var il = getMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);//stack [this]
            il.Emit(OpCodes.Ldfld, delegateFieldBuilder);//stack [this._backingDelegateXXX]
            il.Emit(OpCodes.Callvirt, valueGetter.GetType().GetMethod("Invoke"));//stack [valueReturnedByTheDelegate]
            il.Emit(OpCodes.Ret);
            var propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.None, propertyType, new Type[] { });
            propertyBuilder.SetGetMethod(getMethod);
        }
        public static int Return1()
        {
            return 1;
        }
        private static int Return2()
        {
            return 2;
        }
