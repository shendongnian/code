     Class exmp
     {
        Static void Main(String userinput)
        {
          Int input = 0;
          if( userinput.length > 0 )
          {
            int.TryParse(userinput[0], out input);
          }
        }
     }
