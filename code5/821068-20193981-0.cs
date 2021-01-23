        string a = "IAmVahid";
        List<char> b= new List<char>();
        int j = 0;
        
        for (int i = 0; i < a.Length; i++)
        {
            if (char.IsUpper(a[i]))
            {
                b.Add(' ');
            }
            b.Add(a[i]);
        }
        ouputTxt.Text = new String(b.ToArray()) ;
