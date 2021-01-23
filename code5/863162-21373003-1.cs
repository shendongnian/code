    for(int i = 0; i < myList.Count - 1; i++) {                    
        
         string item  = myList[i];
        
         if (item != null) {
            Assembler.AppendLine("(" + bullet++ + ") " + item);
         } 
    }
    // And for the last item
    Assembler.AppendLine(myList[myList.Count - 1]); 
