    int value = 27;
    string binary = Convert.ToString(value, 2);
    binary = binary.Remove(1,1);  //Remove the exact bit
    int newValue = Convert.ToInt32(binary, 2);
    Console.WriteLine(newValue);
