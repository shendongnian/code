            string a = "abcdefghijklmn";
            List<char> b= new List<char>();
            int j = 0;
            
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 4 == 0)
                    b.Add('-');
                b.Add(a[i]);
            }
            String result = new String(b.ToArray()) ;
