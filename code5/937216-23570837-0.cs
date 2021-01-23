    using (StreamReader sr1 = new StreamReader(fileName))
    {
        while ((line = sr1.ReadLine()) != null)
        {
            commands = line.Split(' ');
            if ((commands.Length > 1) && (commands[1].Contains('X')))
            {
                double X = Convert.ToDouble(commands[1].Substring(1, commands[1].Length - 1).Replace(".", ""));
                double Y = Convert.ToDouble(commands[2].Substring(1, commands[2].Length - 1).Replace(".", ""));
                Un = ((X * 100) / 1.57) / 1000;
                Deux = ((Y * 100) / 1.57) / 1000;
    
                richTextBox2.Text += String.Format("VM M1={0} M2={1}", Un.ToString(".0"), Deux.ToString(".0"));
            }
        }
    }
