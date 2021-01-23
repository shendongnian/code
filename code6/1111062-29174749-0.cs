    Bool isFirst = false;
    int mytempindex;
     private async void mytxt_KeyUp_1(object sender, KeyRoutedEventArgs e)
        {  
          if (e.Key == Windows.System.VirtualKey.Space)
            {
              int i = mytxt.SelectionStart;
              if (i < mytxt.Text.Length)
              {
                if (isfirst == false)
                 { 
                    mytempindex = mytxt.SelectionStart;
                    isfirst = true;
                 }
                else
                 {
                    int mycurrent_index = mytxt.SelectionStart;
                            int templength_index = mycurrent_index - mytempindex;
                    string word = mytxt.Text.Substring(mytempindex, templength_index); //It is the latest entered word.
                   //work with your last word.
                 }
              }
           }
       }
