    public bool IsNumeric(string MyValue)
    {
       bool status = true;
       string Numbers="9876543210";
       char[] D=Numbers.ToCharArray();
       char[] L = MyValue.ToCharArray();
        for (int k = 0; k < L.Length; k++)
        {
            for (int i = 0; i < D.Length; i++)
			{
			  
                  if (L[k]!=D[i])
                {
                    status = false;
                    break;
                }
 
			}
           
        }
        return status;
    }
