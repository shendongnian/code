    int HowManyChars(Graphics g, Font font, string text, Rectangle r)
    {
        float W=0, H=0, MaxH=0;
        int i=0;
        for(i=0; i< text.Length; i++)
        {
            var sz = g.MeasureString(text[i].ToString(), font);
            W+= sz.Width;
           if(W > r.Width) 
           {
               W=sz.Width;
               H+=MaxH;
               MaxH = 0;
               if(H>r.Height) break;
           }
           else
           {
               if(sz.Height > MaxH) MaxH = sz.Height;
           }
        }
        return i;
    }
