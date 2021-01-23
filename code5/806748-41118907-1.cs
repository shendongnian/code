        //this is not an advice, this method is called to produce advices
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            //generic presentation method
            var presentation = typeof(Presentation). GetMethod("Of");
            //example log on exception
            //instance, arguments and exception are Expressions
            yield return Advice.Linq.After.Throwing((instance, arguments, exception) =>
            {
                Expression.Call
                (
                    typeof(Console).GetMethod("WriteLine",...),
                    Expression.Call
                    (
                        typeof(string).GetMethod("Concat", new Type[] { typeof(string[]) }),
                        Expression.NewArrayInit(typeof(string), arguments.Select(argument => argument.Type == typeof(string) ? argument : ...).ToArray())
                    )
                )
            }
        }
    }
  
