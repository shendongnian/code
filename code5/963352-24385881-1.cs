    using (var re = new StreamReader("ficheiro.txt", Encoding.UTF8))
    {
        string input;
        while ((input = re.ReadLine()) != null)
            listBoxTextoOriginal.Items.Add(input);
    }
