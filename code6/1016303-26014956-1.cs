    string T = @"Flowers{Tulip|Sun Flower|Rose}
    
    Gender{Female|Male}
    
    Pets{Cat|Dog|Rabbit}";
                
    foreach (var line in T.Split('\n'))//or while(!file.EndOfFile)
    {
        var S = line.Split(new char[] { '{', '|','}' }, StringSplitOptions.RemoveEmptyEntries);
        string Key = S[0];
        MessageBox.Show(Key);//sth like this
        for (int i = 1 ; i < S.Length; i++)
        {
            string value = S[i];
            MessageBox.Show(value);//sth like this
        }
    }
