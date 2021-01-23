    string[] lines = File.ReadAllLines("C:\\test.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            string[] line = lines[i].Split('^');
            for (int j = 0; j < line.Length; j++)
            {
                textBox1.Text = line[j];
                break;
            }
        }
