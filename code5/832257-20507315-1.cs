    public string CreateArmy(string inputFile)
            {
            string grabFile = inputFile + ".txt";
            int counter = 0;
            string line;
            try
            {
                // Read the file and display it line by line.
                StreamReader file = new StreamReader(grabFile);
            while ((line = file.ReadLine()) != null)
            {
                char[] fixedCommands = line.Remove(0, 3).ToCharArray();
                commands[0] = fixedCommands[0];
                commands[1] = fixedCommands[1];
                commands[2] = fixedCommands[2];
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                commands[].Write(newline, 0, newline.Length);
                counter++;
            }
            char[] newcommands = new string(commands).Remove(0, 3).ToCharArray();
            file.Close();
            MessageBox.Show("There are " + counter + " robots!");
            return null;  // OR return some other string value!
        }
        catch (Exception e)
        {
            MessageBox.Show("Please tell me the .txt file type. Do not include the .txt extension.");
            MessageBox.Show(e.Message);
        }
    }
