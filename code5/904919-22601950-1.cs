    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    namespace GenericCollectionTest
    {
        [TestFixture]
        public class GenericCollectionTest
        {
    
            interface IValiadtor
            {
                bool Validate(object item);
            }
    
            abstract class ValidatorBase<T> : IValidator<T>
            {
                public bool Validate(object item)
                {
                    return Validate((T)item);
                }
    
                public abstract bool Validate(T item);
            }
    
            interface IValidator<T> : IValiadtor
            {
                //Error: "Parameter must be type-safe. Invalid variance..."
                bool Validate(T item);
            }
    
            class MyObject
            {
                public int TestValue { get; set; }
            }
    
            class YourObject
            {
                public int CheckValue { get; set; }
            }
    
            class MyValidator : ValidatorBase<MyObject>
            {
                public override bool Validate(MyObject item)
                {
                    return (item).TestValue == 1;
                }
            }
    
            class YoursValdator : ValidatorBase<YourObject>
            {
                public override bool Validate(YourObject item)
                {
                    return (item).CheckValue == 1;
                }
            }
                    
            [Test]
            public void Test_That_Validator_Is_Working()
            {
                Dictionary<Type, IValiadtor> Validators = new Dictionary<Type, IValiadtor>();
                Validators.Add(typeof(MyObject), new MyValidator() );
                Validators.Add(typeof(YourObject), new YoursValdator());
    
                var someObject = new MyObject();
                someObject.TestValue = 1;
                Assert.That(Validators[someObject.GetType()].Validate(someObject));
    
    
            }
        }
    }
 
