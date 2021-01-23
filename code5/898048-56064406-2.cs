     private string LineBreakLongString(string input)
            {
                var outputString = string.Empty;
                var found = false;
                int pos = 0;
                int prev = 0;
                while (!found)
                    {
                        var p = input.IndexOf(' ', pos);
                        {
                            if (pos <= 30)
                            {
                                pos++;
                                if (p < 30) { prev = p; }
                            }
                            else
                            {
                                found = true;
                            }
                        }
                        outputString = input.Substring(0, prev) + System.Environment.NewLine + input.Substring(prev, input.Length - prev).Trim();
                    }
                return outputString;
            }
