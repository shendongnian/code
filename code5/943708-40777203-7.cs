        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            yield return Advice.Before((instance, arguments) =>
            {
                foreach (var argument in arguments)
                {
                    if (argument == null) { continue; }
                    Email.Validate(argument.ToString());
                }
            });
        }
    }
