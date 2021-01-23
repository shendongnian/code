        public class KeyphraseContentParser
        {
            public string ReplaceKeyphrasesWithLinks(string htmlContent,                                                        IEnumerable<Keyphrase> keyphrases)
            {
                var parsedHtmlStringBuilder = new StringBuilder(htmlContent);
                foreach (var keyphrase in keyphrases)
                {
                    if (htmlContent.CaseContains(keyphrase.Phrase, StringComparison.OrdinalIgnoreCase))
                    {
                        var index = 0;
                        do
                        {
                            index = parsedHtmlStringBuilder.ToString()
                            .IndexOf(keyphrase.Phrase, index, StringComparison.OrdinalIgnoreCase);
                            if (index != -1)
                            {
                                var keyphraseSuffix = parsedHtmlStringBuilder.ToString(index, keyphrase.Phrase.Length + 4);
                                var keyPhraseFromContent = parsedHtmlStringBuilder.ToString(index, keyphrase.Phrase.Length);
                                var keyphraseTarget = "_blank";
                                if (keyphrase.Link.StartsWith("/"))
                                {
                                    keyphraseTarget = "_self";
                                }
                                var keyphraseLinkReplacement = String.Format("<a href='{0}' target='{1}'>{2}</a>",
        keyphrase.Link, keyphraseTarget, keyPhraseFromContent);
                                if (!keyphraseSuffix.Equals(String.Format("{0}</a>", keyPhraseFromContent)))
                                {
                                    parsedHtmlStringBuilder.Remove(index, keyPhraseFromContent.Length);
                                    parsedHtmlStringBuilder.Insert(index, keyphraseLinkReplacement);
                                    index += keyphraseLinkReplacement.Length;
                                }
                                else
                                {
                                    var previousStartBracket = parsedHtmlStringBuilder.ToString().LastIndexOf("<a", index);
                                    var nextEndBracket = parsedHtmlStringBuilder.ToString().IndexOf("a>", index);
                                  parsedHtmlStringBuilder.Remove(previousStartBracket, (nextEndBracket - (previousStartBracket - 2)));
                                       parsedHtmlStringBuilder.Insert(previousStartBracket, keyphraseLinkReplacement);
                            index = previousStartBracket +         keyphraseLinkReplacement.Length;
                                }
                            }
                        } while (index != -1);
                    }
                }
                return parsedHtmlStringBuilder.ToString();
            }
        }
