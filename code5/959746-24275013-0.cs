    string data = "flight%sin";
    int flightNumLength = 4;// Or however long the string would be
    for(int index = 0; index < data.length(); index++)
    {
       if(index+flightNumLength + index < data.length())  
       {
         string TempHolder = data.subSting(index, flightNumLength);
        /* Test here if it could be an integer, if it would be */
    
       }
    }
