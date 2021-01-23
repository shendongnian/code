    private string ConvertDNA(string original)
    {
            StringBuilder newone = new StringBuilder();
            foreach(char c in original)
            {
                switch(c)
                {
                    case 'A':
                        newone.Append('T');
                        break;
                    case 'T':
                        newone.Append('A');
                        break;
                    case 'C':
                        newone.Append('G');
                        break;
                    case 'G':
                        newone.Append('C');
                        break;
                    default:
                        newone.Append(c);
                        break;
                }       
            }
            return newone.ToString();
    }
