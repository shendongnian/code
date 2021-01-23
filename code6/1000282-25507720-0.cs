    {
        string tmpVal = reader.ReadLine(); 
        if(!string.IsNullOrWhiteSpace(tmpVal))
        {
               linesValue[i] = Convert.ToInt32(tmpVal);
        }
    }
