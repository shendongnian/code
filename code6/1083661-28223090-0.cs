    string yourString = "insert your string"
    string[] Splits = yourString.split(",");// Dividing your string by "," chars.
    int i=0;// declaring it here for using it later to check if the number is odd
    for(int i=0; i < Splits.Length-1; i+=2)
    {
    InsertIntoDatabase(Splits[i,i+1]); //Inserting two strings into the database
    }
    //if i is odd, i will be equal exacly to the Length here. Otherwise...
    if(i<Splits.Length)
    {
    InsertIntoDatabase(Splits[i]); // Insert the last string in it's own row.
    }
