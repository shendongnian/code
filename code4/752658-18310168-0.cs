    void input_TextInputStart(object sender, TextCompositionEventArgs e)
        {
            if(input.value.lenght == 2)
              {
                 input.value += '-';.
                 input.SelectionStart(input.Length-1,input.Length-1);
              }
            if(input.value.lenght == 5)
              {
                 input.value += '-';
                 input.SelectionStart(input.Length-1,input.Length-1);
              }
             if(input.value.lenght == 9)
              {
                 input.value += '-';
                 input.SelectionStart(input.Length-1,input.Length-1);
              }
        }
