            string input = "0, 0.25, 0.50, 0.75, 1 , 1.25 , 1.50, 1.75 0.15, 0.20, 0.26, 0.30, 1.30, 1.55";  
            double max = double.MinValue;
            var result = Regex.Replace(input, @"\b\d\.\d+\b", match =>
                                                              {
                                                                  double d = double.Parse(match.Value);
                                                                  // do whatever you want
                                                                  if (d > max)
                                                                      max = d;
                                                                  return "";
                                                              });
