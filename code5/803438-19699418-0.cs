    public bool isValid(TextBox caja)
               {
                   string sTemp;
                   if (caja != null)
                   {
                       sTemp = caja.Text;
                   }
                   else
                   {
                       return false;
                   }
                   
                   if (sTemp.Length > 0)
                   {
                       foreach (char cTemp in sTemp)
                       {
                           if (char.IsNumber(cTemp))
                           {
                               return false;
                           }
                       }
                   }
                   else
                   {
                       return false;
                   }
                   return true;
               }
