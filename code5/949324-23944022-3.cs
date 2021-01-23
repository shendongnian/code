    private void Button_Click(object sender, RoutedEventArgs e)
    {
         // Here im calling the function which returns data to the object
         ProcessedData thoseProcessedData = SomeTestObject(5, "ABC", SomeOtherThing);
    
         // now you can access those properties 
         string useItLikeThis = thoseProcessedData.NewString;
         int numbersLikeThis = thoseProcessedData.NewNumber;
    }
    
    public ProcessedData SomeTestObject(int numbers, string letters, AnotherType anothertype)
    {
         ProcessedData processedData = new ProcessedData();
 
         processedData.newString = letters.Substring(0,5);
         processedData.newNumber = numbers + 10;
         processedData.newType = anothertype.Something();
    
         return processedData;
    }
