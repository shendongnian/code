    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    
    namespace stackoverflow_tests
    {
        [TestFixture]
        public class ReflectionTest
        {
            class Address
            {
                public string Street;
                public string Number;
            }
    
            class Student
            {
                public string Name;
                public string Surname;
                public Address Address;
            }
    
            [Test]
            public void ShouldDisplayNestedClassFields()
            {
                var student = new Student();
                var studentFields = student.GetType().GetFields();
                
                Assert.IsNotNull(studentFields);
                Assert.AreEqual(3, studentFields.Count());
    
                var expectedNames = new []{"Name", "Surname", "Address"};
                var expectedTypes = new[] {typeof(string), typeof(string), typeof(Address)};
    
                for (var fieldIndex = 0; fieldIndex < 3; fieldIndex++)
                {
                    var field = studentFields[fieldIndex];
                    var fieldName = field.Name;
                    Assert.AreEqual(expectedNames[fieldIndex], fieldName);
    
                    var fieldType = field.FieldType;
                    Assert.AreEqual(expectedTypes[fieldIndex], fieldType);
    
                    var childFields = field.FieldType.GetFields();
                    var childFieldCount = childFields.Count();
                    var expectedFieldCount = fieldIndex == 2 ? 2 : 1;
                    Assert.AreEqual(expectedFieldCount, childFieldCount);
                }
            }
    
            [Test]
            public void CanGetFieldNames()
            {
                var expectedResults = new List<string> {"Name", "Surname", "Street", "Number"};
                var student = new Student();
                var actual = GetFieldNames(student.GetType().GetFields());
                Assert.AreEqual(expectedResults, actual);
            }
    
            List<string> GetFieldNames(IEnumerable<FieldInfo> fields)
            {
                var results = new List<string>();
                
                foreach (var fieldInfo in fields)
                {
                    if (fieldInfo.FieldType.GetFields().Count() > 1)
                    {
                        results.AddRange(GetFieldNames(fieldInfo.FieldType.GetFields()));
                    }
                    else
                    {
                        results.Add(fieldInfo.Name);
                    }
                }
                return results;
            }
    
        }
    }
