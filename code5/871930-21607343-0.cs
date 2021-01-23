     short[,] AlleCoordinaten = new short[3, 6] 
        {
             {1,2,3,4,5,6},
             {6,5,4,3,2,1},
             {2,3,4,5,6,7}
        };
    
            XElement elem = new XElement("robot");
            for (int i = 0; i < AlleCoordinaten.GetUpperBound(0); i++)
    		{
                for (int j = 0; j < AlleCoordinaten.GetUpperBound(1); j++)
    		    {
    		        elem.Add(new XElement(string.Format("position{0}",i +1),AlleCoordinaten.GetValue(i,j)));
                }
    		}
