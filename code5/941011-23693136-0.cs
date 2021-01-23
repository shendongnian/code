    string input = 
        Microsoft.VisualBasic.Interaction.InputBox("My Prompt", 
                                                   "The Title", 
                                                   "Desired Default", 
                                                   -1, -1);
    int listSize;
    bool success = int.TryParse(input, out listSize);
