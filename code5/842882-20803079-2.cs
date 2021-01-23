    bool fiftyFiftyUsed = false;
 
    ...
 
    else if (key_pressed.Equals("1") && !fiftyFiftyUsed) // <-- note additional condition here
    {
         char c;
         string erradas = "";
         for (int i = 1; i <= 4; i++)
         {
             if (!levels[current_level][x][i].Equals(resp))
             {
                 c = (char)(i + 64); 
                 erradas = erradas + c;
             }
             else
             { 
                 c = (char)(i + 64); 
                 respostas = respostas + c;
             }
         }
         ajuda_used = true;
         respostas = respostas + HELP5050(erradas); 
         continue;
         fiftyFiftyUsed = true; // <-- and do not forget to set this
     }
