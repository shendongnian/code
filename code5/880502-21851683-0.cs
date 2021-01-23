    SummarizerArguments sumargs = new SummarizerArguments
                                              {
                                                  DictionaryLanguage = "en",
                                                  DisplayLines = sentCount,
                                                  DisplayPercent = 0,
                                                  InputFile = "",
                                                  InputString = OriginalTextBox.Text // here your text
                                              };
    SummarizedDocument doc = Summarizer.Summarize(sumargs);
    string summary = string.Join("\r\n\r\n", doc.Sentences.ToArray());
    // do some stuff with summary. It is your result.
