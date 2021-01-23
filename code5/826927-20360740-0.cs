    int len = 0;
    int index = 0;
    text = string.Join(Environment.NewLine,
                       text.SplitBy(' ')
                           .GroupBy(w =>
                                    { 
                                        if (len + w.Length > 18)
                                        {
                                            len = 0;
                                            index++;
                                        }
                                        len += w.Length + 1;
                                        return index;
                                    })
                           .Select(line => string.Join(" ", line)));
