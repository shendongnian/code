     static public string ReverseOnlyHebrew(string str)
        {
            string[] arrSplit;
            if (str != null && str != "")
            {
                arrSplit = Regex.Split(str, "( )|([א-ת]+)");
                str = "";
                int arrlenth = arrSplit.Length - 1;
                for (int i = arrlenth; i >= 0; i--)
                {
                    if (arrSplit[i] == " ")
                    {
                        str += " ";
                    }
                    else
                    {
                        if (arrSplit[i] != "")
                        {
                            int outInt;
                            if (int.TryParse(arrSplit[i], out outInt))
                            {
                                str += Convert.ToInt32(arrSplit[i]);
                            }
                            else
                            {
                                arrSplit[i] = arrSplit[i].Trim();
                                byte[] codes = System.Text.ASCIIEncoding.Default.GetBytes(arrSplit[i].ToCharArray(), 0, 1);
                                if (codes[0] > 47 && codes[0] < 58 || codes[0] > 64 && codes[0] < 91 || codes[0] > 96 && codes[0] < 123)//EDIT 3.1 reverse just hebrew words                              
                                {
                                    str += arrSplit[i].Trim();
                                }
                                else
                                {
                                    str += Reverse(arrSplit[i]);
                                }
                            }
                        }
                    }
                }
            }
            return str;
        }
            static public string Reverse(string str)
            {
                char[] strArray = str.ToCharArray();
                Array.Reverse(strArray);
                return new string(strArray);
            }
