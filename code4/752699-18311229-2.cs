    void Cheking(string data)
    {
        // Get the enum value of the string passed to the method
        MyEnum myEnumData;
        if (Enum.TryParse<MyEnum>(data, out myEnumData))
        {
            // If the string was a valid enum value iterate over all the value of
            // the underlying enum type
            var values = Enum.GetValues(typeof(MyEnum)).OfType<MyEnum>();
            foreach (var value in values)
            {
                // If the value is not a power of 2 it is a composed one. If it furthermore
                // has the flag passed to the method this is one we searched.
                var isPowerOfTwo = (value != 0) && ((value & (value - 1)) == 0);
                if (!isPowerOfTwo && value.HasFlag(myEnumData))
                {
                    MessageBox.Show(value.ToString());
                }
            }
        }
        // In case an invalid value had been passed to the method
        // display an error message.
        else
        {
            MessageBox.Show("Invalid Value");
        }
    }
