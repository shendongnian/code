    var results= keywords.Select(x=>Regex.Matches(input,@"\b"+x+@"\b")
                                        .Cast<Match>()
                                        .SelectMany(y=>
                                                     new 
                                                     {
                                                         word=y.Value,
                                                         index=y.Index
                                                     }
                                                   )
                                );
