     if (fbalPrice.Contains(" "))
         {
         fbalPrice = fbalPrice.Remove(0, fbalPrice.IndexOf(" ") + 1).Replace(",","").Trim();
         }
     if(fbalsPrice.Contains(" "))
         {
         fbalsPrice = fbalsPrice.Remove(0, fbalsPrice.IndexOf(" ") + 1).Replace(",", "").Trim();
         }
