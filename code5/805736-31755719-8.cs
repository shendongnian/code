    public abstract class JavascriptFunction<TFunction, TDelegate> where TFunction : JavascriptFunction<TFunction, TDelegate>, new()
    {
        private static  TFunction   instance    = new TFunction();
        private static  string      name        = typeof(TFunction).Name;
        private         string      functionBody;
        protected JavascriptFunction(string functionBody) { this.functionBody = functionBody; }
        public static string Call(Expression<Action<TDelegate>> func)
        {
            return instance.EmitFunctionCall(func);
        }
        public static string EmitFunction()
        {
            return "function " + name + "(" + extractParameterNames() + ")\r\n{\r\n    " + instance.functionBody.Replace("\n", "\n    ") + "\r\n}\r\n";
        }
        private string EmitFunctionCall(Expression<Action<TDelegate>> func)
        {
            return name + "(" + this.extractArgumentValues(((InvocationExpression) func.Body).Arguments) + ");";
        }
        private string extractArgumentValues(System.Collections.ObjectModel.ReadOnlyCollection<Expression> arguments)
        {
            System.Text.StringBuilder   returnString    = new System.Text.StringBuilder();
            string                      commaOrBlank    = "";
            foreach(var argument in arguments)
            {
                returnString.Append(commaOrBlank + this.getArgumentLiteral(argument));
                commaOrBlank    = ", ";
            }
            return returnString.ToString();
        }
        private string getArgumentLiteral(Expression argument)
        {
            if (argument.NodeType == ExpressionType.Constant)   return this.getConstantFromArgument((ConstantExpression) argument);
            else                                                return argument.ToString();
        }
        private string getConstantFromArgument(ConstantExpression constantExpression)
        {
            if (constantExpression.Type == typeof(String))  return "'" + constantExpression.Value.ToString().Replace("'", "\\'") + "'";
            if (constantExpression.Type == typeof(Boolean)) return constantExpression.Value.ToString().ToLower();
            return constantExpression.Value.ToString();
        }
        private static string extractParameterNames()
        {
            System.Text.StringBuilder   returnString    = new System.Text.StringBuilder();
            string                      commaOrBlank    = "";
            MethodInfo method = typeof(TDelegate).GetMethod("Invoke");
            foreach (ParameterInfo param in method.GetParameters())
            {
                returnString.Append(commaOrBlank  + param.Name);
                commaOrBlank = ", ";
            }
            return returnString.ToString();
        }
    }
