                Dictionary<string,string> _dic=new Dictionary<string,string>();
                string line = "1 03/MAR/2013 06:41:06 9448485859 00:15 0.40 **";
                string line1 = "SNo Date Time Number Duration/Volume Amount";
                line.Replace('*',' ');
                string[] split1 = line.Split(new Char[] { ' ' });
                string[] split2 = line1.Split(new Char[] { ' ' });
                for(int _i=0;_i<line.Length;_i++)
                {
                _dic.Add(split1[_i], split2[_i]);
                }
