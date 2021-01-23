    public class SomeClass
    {
        public void SomeMethod()
        {
            Person somePerson = new Person();
            GenericList<IGenericObject<object>> listWithGenericsOfObject = new GenericList<IGenericObject<object>>();
            listWithGenericsOfObject.Add(somePerson);
            GenericList<IGenericObject<string>> listWithGenericsOfString = new GenericList<IGenericObject<string>>();
            listWithGenericsOfString.Add(somePerson);
            GenericList<Person> listWithGenericsOfPerson = new GenericList<Person>();
            listWithGenericsOfPerson.Add(somePerson);
        }
    }
