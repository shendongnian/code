        private static List<string> GetLists(string sText)
        {
            string[] output;
            List<string> input = new List<string>();
            input = sText.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            int count = input.Count(x => x == "SOI;");
            output = new string[count]; // set output array to number of lists in string
            int current = -1;  // start with -1 so first SOI will set it on 0
            int max = -1;
            foreach (var text in input)
            {
                if (text == "SOI;") // set current and max
                {
                    current++;
                    max++;
                }
                else if (text == "EOI;")
                {
                    current--;
                    if (current == -1)  // if u reached -1 it means u are out of any list so set current on max so if u will get "SOI" u will get proper number
                    {
                        current = max;
                    }
                }
                else
                {
                    output[current] += text;
                }
            }
            return output.ToList();
        }
    }
