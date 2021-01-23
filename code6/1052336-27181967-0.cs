     static void Main(string[] args)
            {
                char[] ptrArr = new[] { '0','1','0','1','0','1','0','1' };
                char[] ptrArr2=  new char[0];
                List<char> ptrArr2temp = new List<char>();
                
                for (int i = 0; i < ptrArr.Length; i++)
                {   
                    ptrArr2temp.Add(ptrArr[i]);
                }
                
                for (int i = 0; i < ptrArr.Length; i++)
                {
                    int internalIndex = ((int)(Math.Pow(2, i))) - 1;
                    if (ptrArr2temp.Count > internalIndex)
                    {
                        ptrArr2temp.Insert(internalIndex, '*');
                    }
                }
                ptrArr2 = ptrArr2temp.ToArray();          
            }
