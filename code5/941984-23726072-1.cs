    public List<String> ReadAllAnswers()
    {
        stream = File.OpenText("answers.txt");
        String[] answers;
        string line = stream.ReadLine();
        return line.Split('|', StringSplitOptions.RemoveEmptyEntries);
    }
