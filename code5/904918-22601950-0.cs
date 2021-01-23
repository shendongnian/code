    using NUnit.Framework;
    namespace GenericCollectionTest
    {
        [TestFixture]
        public class GenericCollectionTest
        {
            //.NET Compiling Error:
            //"Invalid variance: The type parameter 'T' must be contravariantly valid ..."
            interface IValidator<out T>
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
            
            class MyValidator : IValidator<MyObject>
            {
                public bool Validate(MyObject item)
                {
                    return (item).TestValue == 1;
                }
            }
    
            class YoursValdator : IValidator<YourObject>
            {
                public bool Validate(YourObject item)
                {
                    return (item).CheckValue == 1;
                }
            }
            
            [Test]
            public void Test_That_Validator_Is_Working()
            {
                //.NET compiler tries to prevent the following scenario:
    
                IValidator<object> someObjectValidator = new MyValidator();
                someObjectValidator.Validate(new YourObject()); // Can't use MyValidator to validate Yourobject
    
                someObjectValidator = new YoursValdator();
                someObjectValidator.Validate(new MyObject()); // Can't use YoursValidator to validate MyObject
    
            }
        }
    }
