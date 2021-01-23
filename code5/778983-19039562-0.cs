            List<char> c_list = new List<char>();
            string src = "A~B~C~D";
            char [] c = src.ToCharArray();
            foreach (char cc in c)
            {
                if (cc != '~')
                    c_list.Add(cc);
            }
   
