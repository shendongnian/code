        string value = calcu.Text;
            char[] delimiters = new char[] { '+', '-', '*', '/' };
            string[] parts = value.Split(delimiters);
            string[] signs = Regex.Split(value, "[0-9]|\\.").Where(s => !String.IsNullOrEmpty(s)).ToArray(); ;
            float numCtr = 0, lastVal = 0;
            string lastOp = "";
            foreach (string n in parts)
            {
                numCtr++;
                if (numCtr == 1)
                {
                    lastVal = float.Parse(n);
                }
                else
                {
                    if (!String.IsNullOrEmpty(lastOp))
                    {
                        switch (lastOp)
                        {
                            case "+":
                                lastVal = lastVal + float.Parse(n);
                                break;
                            case "-":
                                lastVal = lastVal - float.Parse(n);
                                break;
                            case "*":
                                lastVal = lastVal * float.Parse(n);
                                break;
                            case "/":
                                lastVal = lastVal / float.Parse(n);
                                break;
                        }
                    }
                }
                float opCtr = 0;
                foreach (string o in signs)
                {
                    opCtr++;
                    if (opCtr == numCtr)
                    {
                        lastOp = o;
                        break;
                    }
                }
            }
            calcu.Text = lastVal.ToString();
