    while (index < correctAnswers.Length && !sReader.EndOfStream)
    {
        correctAnswers[index] = sReader.ReadLine();
        index++;
    }
    foreach (string str in correctAnswers)
    {
        listBox1.Items.Add(str);
    }
