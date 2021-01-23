    public void transferGameBase(List<string> infoBase)
        {
            int count = 0;
    
            foreach(string _base in infoBase)
            {
                string[] _splitter = infoBase[count].ToString().Split(';');
                drawBase(Convert.ToInt16(_splitter[0]), Convert.ToInt16(_splitter[1]), Convert.ToInt16(_splitter[2])); //[0] = x , [1] = y, [2] = size
                count++;
            }
    
            this.Invalidate();
    
        }
