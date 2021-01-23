    public void Challenge()
        {
            var c = 354939801;
            var slt = "zws0mUwF";
            var s1 = 'h';
            var s2 = 'l';
            var n = 4;
            var start = (int)s1;
            var end = (int)s2;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            var m = Math.Pow((start - end) + 1, n);
            for (int i = 0; i < n; i++)
            {
                sb.Append(s1);
            }
            var str = sb.ToString().ToCharArray();
            for (int i = 0; i < (m - 1); i++)
            {
                for (int j = n - 1; j >= 0; --j)
                {
                    var t = (int)str[j];
                    t++;
                    str[j] = (char)t;
                    if ((int)str[j] <= (int)end)
                    {
                        break;
                    }
                    else
                    {
                        str[j] = s1;
                    }
                }
                var chlg = str.ToString();
            }
        }
