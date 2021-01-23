            if (line.ToLower().Contains(" apt "))
            {
                String[] sParts = line.Split(' ');
                string finishedLine = "";
                for(int i = 0; i < sParts.Length; i++)
                {
                    if (sParts[i].ToLower().Equals("apt"))
                    {
                        i++;
                    }
                    else
                    {
                        finishedLine += sParts[i] + " ";
                    }
                }
                line = finishedLine.Trim();
            }
