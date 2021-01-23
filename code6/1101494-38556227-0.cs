    /// <summary>
        /// Iterates through texts, concatenates them and looks for tokens to replace 
        /// </summary>
        /// <param name="texts"></param>
        /// <param name="tokenNameValuePairs"></param>
        /// <returns>T/F whether a token was replaced.  Should loop this call until it returns false.</returns>
        private bool IterateTextsAndTokenReplace(IEnumerable<Text> texts, IDictionary<string, object> tokenNameValuePairs)
        {
            List<Text> tokenRuns = new List<Text>();
            string runAggregate = String.Empty;
            bool replacedAToken = false;
            foreach (var run in texts)
            {
                if (run.Text.Contains(prefixTokenString) || runAggregate.Contains(prefixTokenString))
                {
                    runAggregate += run.Text;
                    tokenRuns.Add(run);
                    if (run.Text.Contains(suffixTokenString))
                    {
                        if (possibleTokenRegex.IsMatch(runAggregate))
                        {
                            string possibleToken = possibleTokenRegex.Match(runAggregate).Value;
                            string innerToken = possibleToken.Replace(prefixTokenString, String.Empty).Replace(suffixTokenString, String.Empty);
                            if (tokenNameValuePairs.ContainsKey(innerToken))
                            {
                                //found token!!!
                                string replacementText = runAggregate.Replace(prefixTokenString + innerToken + suffixTokenString, Convert.ToString(tokenNameValuePairs[innerToken]));
                                Text newRun = new Text(replacementText);
                                run.InsertAfterSelf(newRun);
                                foreach (Text runToDelete in tokenRuns)
                                {
                                    runToDelete.Remove();
                                }
                                replacedAToken = true;
                            }
                        }
                        runAggregate = String.Empty;
                        tokenRuns.Clear();
                    }
                }
            }
            return replacedAToken;
        }
--------------
    string prefixTokenString = "{";
        string suffixTokenString = "}";
        Regex possibleTokenRegex = new Regex(prefixTokenString + "[a-zA-Z0-9-_]+" + suffixTokenString);
