            string userUtterance = "I want identification number for number of customers";
            string pattern1 = "identification number";
            string pattern2 = "\btom \b";
            string pattern3 = "\bid \b";
            string replacement = "{YourWordHere}"
            string newuserUtterance = userUtterance.Replace(pattern1, replacement );
            bool match2 = Regex.IsMatch(newuserUtterance, pattern2); // should not match
            bool match3 = Regex.IsMatch(newuserUtterance, pattern3); // should not match
