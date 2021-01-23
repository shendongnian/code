            System.Text.StringBuilder lines = new System.Text.StringBuilder();
            while (!logFileReader.EndOfStream)
            {
            lines.AppendLine(logFileReader.ReadLine());
            }
