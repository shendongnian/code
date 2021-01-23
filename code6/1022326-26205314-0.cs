    for(int i = 0; i < strList.Length; i++)
    {   
      Uri uriToCompare = new Uri(strArray[i]);
      for(int j = i+1; j < strArray.Length; j++){
         Uri uri = new Uri(strArray[j]);
         if( uriToCompare.Host  == uri.Host){
            strList.RemoveAt(j);
         }     
      }
    }
