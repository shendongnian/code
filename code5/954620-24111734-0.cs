                DateTime dtfrom;
                DateTime dtto;
           
                if(DateTime.TryParse(from.Text,out dtfrom) && DateTime.Parse(to.Text,out dtto);)
                {
                    string from = dtfrom.ToShortDateString();
                    string to = dtto.ToShortDateString();
                }
                else
                {
                    //Parsing Error
                }  
