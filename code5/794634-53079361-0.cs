    string getMode()
        {
            IDictionary<float, int> mode = new Dictionary<float, int>();    //Dictionary (Float is the number) (Int is  the occurences)
            foreach (float number in numbers)                               //Loop through List named numbers (List is made of floats)
            {
                if (mode.ContainsKey(number))                               //If dictionary already contains current number increase occurences by 1
                {
                    mode[number] ++;
                }
                else
                {
                    mode.Add(number, 1);                                    //If dictionary does not contain current number add new occurence
                }
            }
            List<float> currentMax = new List<float>();                     //Create new List of the max number
            int occurences = 0;                                             //Max occurences
            bool foundMultiple = false;                                     //Check if multiple found
            foreach (KeyValuePair<float, int> entry in mode.Reverse())      //Loop through dictionary
            {
                if(occurences < entry.Value)                                //If occurences is smaller than current input
                                                                            //Clear old input and add current number to list
                {
                    currentMax.Clear();
                    currentMax.Add(entry.Key);
                    occurences = entry.Value;
                    foundMultiple = false;
                }
                else if(occurences == entry.Value)                          //If number with the same amount of occurences occures
                                                                            //Add to List
                {
                    currentMax.Add(entry.Key);
                    foundMultiple = true;
                }
            }
            string returnText = "";                                         //Text to return
            if(foundMultiple == true)                                           
            {
               foreach(float number in currentMax)                          //Loop through text
                {
                    returnText += number.ToString() + ",";                  //Add to return text
                }
            }
            else
            {
                returnText = numbers[0].ToString();                         //If there aren't multiple return just first index
            }
            if (returnText.EndsWith(","))
            {
                returnText = returnText.Remove(returnText.Length - 1);      //Format string to avoid a comma at the end
            }
            return returnText;
        }
