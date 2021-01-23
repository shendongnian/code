    public static string Mask_IT(this string source, char MaskingChar, int AllowedCharCount)
      {
         var cArr = source.ToCharArray();
    
         if(source.Length - AllowedCharCount >=0)
         {
        
             for (int i = 0; i < ( cArr.Length - AllowedCharCount; i++ )
             {
              if (cArr[i] != MaskingChar) cArr[i] = MaskingChar;
             }
         }
        
             return cArr.ToString();
      }
