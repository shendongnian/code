    public void SayMyType(BaseClass obj)
    {
          Console.Write(obj.GetType())//will output the type of object 'DerivedClass' not the parameter 'BaseClass '
    }
    SayMyType(new DerivedClass())
