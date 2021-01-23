    private string GetFormattedOutput(List<int> selectedCB)
        {
            // Can be changed if you want to increase
            // groupby range
            int rangeBy = 3;    
            int diffBy = 1;
            int prevValue = 0;
            List<int> tempList = new List<int>();
            StringBuilder formattedOutput = new StringBuilder();
            foreach (int currentValue in selectedCB)
            {
                var diff = currentValue - prevValue;
         
                if(tempList.Count != 0 && diff > diffBy)
                {
                    // Add the value in templist to formatted output
                    // If three are more numbers are in range
                    // Add the first and last
                    if (tempList.Count >= rangeBy)
                    {
                        formattedOutput.Append(tempList[0].ToString() + "-" +
                                               tempList[tempList.Count - 1].ToString()+",");
                    }
                    else
                    {
                        AppendText(formattedOutput, tempList);
                    }
                    tempList.Clear();
                }
                tempList.Add(currentValue);
                prevValue = currentValue;
            }
            if (tempList.Count != 0)
            {
                AppendText(formattedOutput, tempList);
            }
            formattedOutput.Remove(formattedOutput.Length - 1, 1);
            return formattedOutput.ToString();
        }
        // To append the numbers in the list
        string AppendText(StringBuilder output, List<int> tempList)
        {
            foreach (var temp in tempList)
            {
                output.Append(temp.ToString() + ",");
            }
            return output.ToString();
        }
