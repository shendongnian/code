    String input = "01018200000c000000000000000000000003";
    if(input.IndexOf("c")!=0){
         String portion = input.Substring(input.IndexOf("c")+1); // Note the 0 based index 
         Console.WriteLine(portion); // Verify test
    }
