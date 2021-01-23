    int Number;
    bool result = Int32.TryParse(comboBox1.ValueMember, out Number);
    if (result)
    {
       Console.WriteLine("Converted '{0}' to {1}.", comboBox1.ValueMember, Number);         
    }
    else
    {
      //conversion failed
      //Int32.Parse, would throw a formatexception here.
    }
