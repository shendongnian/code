    public class Person
    {
        [MyOtherAttribute]
        public virtual string Name { get; set; }
        [MyOtherAttribute]
        public virtual int Age { get; set; }
    }
    private void MyOtherMethod()
    {
        PersonForm person = new PersonForm();
        Save(person);
    }    
    public void Save(Person person)
    {
       var type = person.GetType(); //type here is PersonForm because that is what was passed by MyOtherMethod.
      
       //GetProperties return all properties of the object hierarchy
       foreach (var propertyInfo in personForm.GetType().GetProperties()) 
       {
           //This will return all custom attributes of the property whether the property was defined in the parent class or type of the actual person instance.
           // So for Name property this will return MyAttribute and for Age property MyOtherAttribute
           Attribute.GetCustomAttributes(propertyInfo, false);
           //This will return all custom attributes of the property and even the ones defined in the parent class.
           // So for Name property this will return MyAttribute and MyOtherAttribute.
           Attribute.GetCustomAttributes(propertyInfo, true); //true for inherit param
       }
    }
