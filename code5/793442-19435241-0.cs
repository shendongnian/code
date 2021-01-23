        [TestMethod]
        public void TestMethod()
        {
            var john = new Person() { Name = "John" };
            var tom = new Person() { Name = "Tom" };
            var person1 = john;
            var person2 = tom;
            SwapPersonsMethod1(person1, person2);
            //Person1 is still John
            Assert.AreEqual(person1, john);
            //Person2 is still Tom
            Assert.AreEqual(person2, tom);
            SwapPersonsMethod2(ref person1, ref person2);
            //Person1 is still Tom
            Assert.AreEqual(person1, tom);
            //Person2 is still John
            Assert.AreEqual(person2, john);
            UpdateName(person1, "Tomas");
            //Person1 is pointing to var tom, and its name now is Tomas.
            Assert.AreEqual(person1.Name, "Tomas");
            Assert.AreEqual(tom.Name, "Tomas");
        }
        private void UpdateName(Person person, string name)
        {
            person.Name = name;
        }
        private void SwapPersonsMethod1(Person person1, Person person2)
        {
            var aux = person1;
            person1 = person2;
            person2 = aux;
        }
        private void SwapPersonsMethod2(ref Person person1, ref Person person2)
        {
            var aux = person1;
            person1 = person2;
            person2 = aux;
        }
        public class Person
        {
            public string Name { get; set; }
        }
