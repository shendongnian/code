    SummarizerArguments sumargs = new SummarizerArguments
                                              {
                                                  DictionaryLanguage = "en",
                                                  DisplayLines = sentCount,
                                                  DisplayPercent = 0,
                                                  InputFile = "",
                                                  InputString = OriginalTextBox.Text
                                              };
            SummarizedDocument doc = Summarizer.Summarize(sumargs);
            string summary = string.Join("\r\n\r\n", doc.Sentences.ToArray());
