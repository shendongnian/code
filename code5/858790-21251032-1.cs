        protected void Btn_Click(object sender, Eventargs e)
        {
          if(viewstate["val"] != null)
            {
                     int s = (int)viewstate["val"];
                     s= s + 5 ;
        
                    viewstate["val"] = s
            }
         else
            {
                    viewstate["val"] = 5 // whatever
              }
        }
