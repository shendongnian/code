    try
    {
        int a2 = Int.Parse(textBox1.Text);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Failed to parse to int! " + ex.Message);
    }
