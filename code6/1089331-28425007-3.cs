    String input = "01018200000c000000000000000000000003"; // This is input you get
    String portion;
    if(input.Length > 4){ 
        if(input.IndexOf("c")!=0){
              portion = input.Substring(input.IndexOf("c")+1); // Note the 0 based index 
              Console.WriteLine(portion); // Verify test
              textbox_one.Text = portion;
       }
       else{
             // Not a valid tag
             textbox_one.Text = "Error Tag :" + input;
       }
    }  
