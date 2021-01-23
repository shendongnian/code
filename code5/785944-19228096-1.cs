    List<Func<char>> generators = new List<Func<char>>();
    if (lowercaseCheckbox.Checked)
        generators.Add(() => gen.lowercase());
    if (uppercaseCheckbox.Checked)
        generators.Add(() => gen.uppercase());
    if (numberCheckbox.Checked)
        generators.Add(() => gen.number());
    int length = Convert.ToInt32(lengthTextBox.Text);
    StringBuilder password = new StringBuilder();
    Random random = new Random();
    for (int i = 0; i < length; i++)
    {
        int choice = random.Next(generators.Count);
        password.Append(generators[choice]());
    }
    string result = password.ToString();
