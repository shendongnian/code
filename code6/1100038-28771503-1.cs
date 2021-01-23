    int value = 27;
    string binary = Convert.ToString(value, 2);
    binary = binary.Remove(binary.Length-3-1,1);  //Remove the exact bit, 3rd in this case
    int newValue = Convert.ToInt32(binary, 2);
    Console.WriteLine(newValue);
