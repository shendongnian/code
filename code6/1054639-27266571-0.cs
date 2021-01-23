    string ColumnString = (values[Column]);
    string NA = "#N/A";
    if (string.Compare(ColumnString,NA)==0)
    { 
     Console.WriteLine(values[Column]);
     Console.WriteLine("non numeric value detected, Skipping line #{0}", LineNumber);
     break;
    }
