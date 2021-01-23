    private void findConsecutive()
    {
    
    	var vertical = (from Control cnt in pnlCrossWord.Controls
    					where (cnt.GetType().Name.Equals("TextBox")) && (!cnt.BackColor.Equals(Color.Black))
    					orderby cnt.Top
    					select cnt.Top).Distinct().ToArray();
    	var horizontal = (from Control cnt in pnlCrossWord.Controls
    					where (cnt.GetType().Name.Equals("TextBox")) && (!cnt.BackColor.Equals(Color.Black))
    					orderby cnt.Left
    					  select cnt.Left).Distinct().ToArray();
    
    	List<int> vList = new List<int>();
    	int iIndex = 0;
    	
    	foreach (int top in vertical)
    	{
    		vList.Add(0);
    		int vIndex = 0;
    		int iConsecutive = 0;
    		int iLastLeft = -1;
    		var Item = (from Control cnt in pnlCrossWord.Controls
    					where (cnt.GetType().Name.Equals("TextBox")) && (!cnt.BackColor.Equals(Color.Black))
    					&& (cnt.Top.Equals(top))
    					select (TextBox)cnt).ToArray();
    		foreach (TextBox txt in Item)
    		{
    			if ((iLastLeft + txt.Width) < txt.Left && iLastLeft > -1)
    			{
    				if (iConsecutive > vList[iIndex])
    					vList[iIndex] = iConsecutive;
    
    				iConsecutive = 0;
    			}
    			
    			iConsecutive++;
    
    			iLastLeft = txt.Left;
    			vIndex++;
    		}
    		if (iConsecutive > vList[iIndex])
    			vList[iIndex] = iConsecutive;
    		iIndex++;
    	}
    
    	int MaxConsicutiveIndex = vList.IndexOf(vList.Max());           
    }
