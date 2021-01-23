    private string strGetIndentString()
            {
                ArrayList nArr = new ArrayList();
                System.Text.StringBuilder strInfo = new System.Text.StringBuilder();
    
                if (Session["CHECKED_ITEMS"] != null)
                    nArr =(ArrayList) Session["CHECKED_ITEMS"];//throws error
    
                for (int i = 0; i < nArr.Count; i++)
                    strInfo.Append(nArr[i].ToString() + ",");
    
                return strInfo.ToString().TrimEnd(",".ToCharArray());
    
            }
