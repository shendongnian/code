        public static Double getElements(String _molecule)
        {
            MatchCollection findMatches = Regex.Matches(_molecule, @"\(?[A-Z][a-z]?\d*\)?"); // Get all elements
            Double endNumber = Double.Parse(Regex.IsMatch(_molecule, @"\)\d+") ? Regex.Match(_molecule, @"\)\d+").Value.Remove(0,1) : "1"); // Finds the number after the ')'
            foreach (Match i in findMatches)
            {
                String element = Regex.Match(i.Value, "[A-Z][a-z]?").Value; // Gets the element
                Double amountOfElement = 0;
                if (Regex.IsMatch(i.Value, @"[\(\)]"))
                {
                    if (!Double.TryParse(Regex.Replace(i.Value, @"(\(|\)|[A-Z]|[a-z])", ""), out amountOfElement))
                        amountOfElement = endNumber; // If the element has either '(' or ')' and doesn't specify an amount, then set it equal to the endnumber
                    else
                        amountOfElement *= endNumber; // If the element has either '(' or ')' and specifies an amount, then multiply it by the end number
                }
                else
                    amountOfElement = Double.Parse(String.IsNullOrWhiteSpace(i.Value.Replace(element, "")) ? "1" : i.Value.Replace(element, ""));
                MessageBox.Show(element + " - " + amountOfElement);
            }
            return endNumber;
        }
