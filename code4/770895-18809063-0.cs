            string s = "123,45636...";      
            int index = 7;
            while (true)
            {
                if (s[index] == ',')
                {
                    s = s.Substring(0, index);
                    break;
                }
                else
                {
                    index--;
                }
            }
