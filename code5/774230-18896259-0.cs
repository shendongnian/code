     int space = 0;
     string finalString =""; 
     for (i = 0; i < txtbox.lenght; i++)
     {
           finalString  = finalString  + string[i];
           space++;
            if (space = 3 )
            {
                finalString  = finalString  + " ";
                space = 0;
            }
     }
