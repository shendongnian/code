    while (index < correctAnswers.Length && !sReader.EndOfStream)
    {
        studentAnswers[index] = sReader.ReadLine();
        index++;
    }
    foreach (string str in studentAnswers)
    {
        listBox1.Items.Add(str);
    }
