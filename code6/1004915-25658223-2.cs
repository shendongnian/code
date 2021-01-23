    if (tags != null)
                {
                    string ConTitle = String.Join("", tags);
                    string FullTitle = Regex.Match(ConTitle,
                      "(StreamTitle=')(.*)(';StreamUrl)").Groups[2].Value.Trim();
                    string[] Title = Regex.Split(FullTitle, " - ");
                    return Title;
                }          
