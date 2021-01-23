    Dictionary<string, string> replacements = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        // Fill the dictionary with the proper replacements:
        
            StringBuilder patternBuilder = new StringBuilder();
                    patternBuilder.Append('(');
        
                    bool firstReplacement = true;
        
                    foreach (var replacement in replacements.Keys)
                    {
                        if (!firstReplacement)
                            patternBuilder.Append('|');
                        else
                            firstReplacement = false;
        
                        patternBuilder.Append('(');
                        patternBuilder.Append(Regex.Escape(replacement));
                        patternBuilder.Append(')');
                    }
                    patternBuilder.Append(')');
        
                    var regex = new Regex(patternBuilder.ToString(), RegexOptions.IgnoreCase);
        
                    return regex.Replace(sourceContent, new MatchEvaluator(match => replacements[match.Groups[1].Value]));
