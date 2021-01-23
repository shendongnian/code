    private void GETNUMERICDATA()
    {
        int currentPosition = 0;
        string txt = textbox1.text;
        txt = txt.Replace(" ", string.Empty);
        
        for (int k = 0; k < 32 && currentPosition < txt.Length; k++)
        {
            for (int l = 0; l < 32 && currentPosition < txt.Length; l++)
            {
                char chr = txt[currentPosition];
        
                if (chr == '0')
        		{
                    Matrix[k, l] = (int)char.GetNumericValue('0');
        		}
        		else if (chr == '1')
    			{
                    Matrix[k, l] = (int)char.GetNumericValue('1');
        		}
    			
    			currentPosition++;
        	}
        }
    }
