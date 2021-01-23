    public static String BeautifyPhoneNumber(string numberToBeautify)
        {
            //The below gives us capture groups for each 
            //individual piece of the number.
            var regularExpression = new Regex(@"(\d{3})(\d{3})(\d{4})(x\d*)?");
            //This matches a number that's already been beautified, 
            //so we can guard against beautifying twice.
            var alreadyBeautifulExpression = new Regex(@"(\(\d{3}\)) (\d{3})-(\d{4}) ?(x\d*)?");
            var beautifulNumber = string.Empty;
            var separator = "-";
            var space = " ";
            //This prevents us from accidentally beautifying 
            //something more than once
            //You could also guard against this in your getter using a
            //IsBeautified extension, using the alreadyBeautifulExpression above
            if (alreadyBeautifulExpression.IsMatch(numberToBeautify))
            {
                return numberToBeautify;
            }
            //Trying to protect against invalid input... May be insufficient,
            //Or unnecessary
            if (string.IsNullOrEmpty(numberToBeautify) 
                || regularExpression.Matches(numberToBeautify).Count <= 0)
            {
                return beautifulNumber;
            }
            GroupCollection groups = regularExpression.Matches(
                                                    numberToBeautify)[0].Groups;
            //More protection against invalid input
            if (groups.Count < 3)
            {
                return beautifulNumber;
            }
            
            //Given "7689131234",
            beautifulNumber += "(" + groups[1] + ")" + space; //gives us "(768) "
            beautifulNumber += groups[2] + separator; //gives us "(768) 913-"
            beautifulNumber += groups[3]; //gives us "(768) 913-1234"
            //If we have an extension, we add it.
            if (groups[4] != null)
            {
                beautifulNumber += space + groups[4];
            }
            return beautifulNumber;
        }
