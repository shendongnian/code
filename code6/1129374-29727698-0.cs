    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using FluentValidation;
    using FluentValidation.Results;
    
    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                var c = new MyClass();
                var result = Validate(c);
            }
    
            public static ValidationResult Validate(object c)
            {
                if (c == null) throw new ArgumentNullException("c");
    
                var vt = typeof (AbstractValidator<>);
                var et = c.GetType();
                var evt = vt.MakeGenericType(et);
    
                var validatorType = FindValidatorType(Assembly.GetExecutingAssembly(), evt);
    
                var validatorInstance = (IValidator)Activator.CreateInstance(validatorType);
                return validatorInstance.Validate(c);
            }
    
    
            public static Type FindValidatorType(Assembly assembly, Type evt)
            {
                if (assembly == null) throw new ArgumentNullException("assembly");
                if (evt == null) throw new ArgumentNullException("evt");
                return assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(evt));
            }
        }
    
    
        public class MyClassValidator : AbstractValidator<MyClass>
        {
            
        }
    
        public class MyClass
        {
            
        }
    }
