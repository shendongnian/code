    public Form1()
    {
        InitializeComponent();
        StreamWriter outputFile;
        outputFile = File.CreateText("names.txt");
        foreach (string name in names)
        {
            outputFile.WriteLine(name);
        }
        outputFile.Close();
        string studentName;
        StreamReader inputFile;
        inputFile = File.OpenText("names.txt");
        while (!inputFile.EndOfStream)
        {
            //Reads name from text file
            studentName = inputFile.ReadLine();
            //Writes name to listbox
            nameListBox.Items.Add(studentName);
        }
        inputFile.Close();
    }
