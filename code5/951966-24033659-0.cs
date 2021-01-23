             static string MethodName(int range){
             StringBuilder sb = new StringBuilder();
             for(int i = 0 ; i < str.Length ; i++){
              if(i % 4 == 0){
                 sb.Append(str[i]);
                 for(int j = i + 1 ; j <= i + range ; j ++){
                   if(j >= str.Length)
                         break;             
                      sb.Append(str[j]);
              }
            }
        }
         return sb.ToString();
       }
