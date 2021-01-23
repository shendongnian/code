    listSalaryProperty.AddRange(
        ListSalary.Zip(ListSalary.Skip(1),
                       (a, b) => new
                                 {
                                     From = a,
                                     To = b,
                                     Text = string.format("{0} - {1}", a, b)
                                 }
                 ).Select(g => new KeyValuePair<string, YourValueType>(
                                       g.Text,
                                       /* value code here */
                                   )));
