        public static Action fromString(string className, string defName, WorldObject actor)
        {
            //Get the Assembly (namespace)
            Assembly assembly = Assembly.Load("Actions");
            //Get the exact class Type
            Type t = assembly.GetType("Actions." + className);
            //Get the info about constructor (using array literal)
            // - for every accepted parameter enter typeof(parameterType)
            ConstructorInfo constructor = t.GetConstructor(new Type[] { typeof(string), typeof(WorldObject) });
            //Initialise the Type instance
            System.Object action = constructor.Invoke(new System.Object[] { defName, actor });
            //If it's child of the main class
            if (action is Action)
                return (Action)action;
            //Error otherwise
            else
            {
                Debug.LogError("'" + className + "' is not child of Action!");
                return null;
            }
        }
