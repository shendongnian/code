    private void General<T>()
    {
       var values = Enum.GetValues(typeof(T));
       foreach(var value in values)
           Console.WriteLine(var);
    }
    
    General<Enum1>();
    General<Enum2>();
    General<Enum3>();
