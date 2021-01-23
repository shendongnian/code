    private void TweakInputLines(string InputData)
        {
            List<string> lstInput = new List<string>();
            var returnstring = "";
            if (!string.IsNullOrEmpty(InputData))
            {
                lstInput = InputData.Split('\n').ToList();
                if (lstInput.Count > 9999)
                {
                    int counter = 0;
                    foreach (var eachcharitem in lstInput)
                    {
                        counter++;
                        returnstring = returnstring + eachcharitem;
                        if (counter == 5)
                        {
                            returnstring = returnstring + "|";
                            counter = 0;
                        }
                    }
                }
            }
        }
