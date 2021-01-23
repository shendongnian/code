CSharp
ExcelReader reader = new ExcelReader("path/to/ExcelFile.xlsx");
reader.ReadNext(); //for the purposes of this example we'll skip the first line
/*The code within the while loop will read the data in rows 2-7, then rows 8-13, etc.*/
while (reader.ReadNext())
{
    Console.WriteLine("Header Cell:");
    Console.WriteLine(reader.Value); //Writes the value of cell A2
    reader.ReadNext(); //Moves the reader to the next cell, e.g.. the start of row 3
    do
    {
        Console.WriteLine("Value at cell" + reader.Address);
        Console.WriteLine(reader.Value);
    } while(reader.ReadNextInRow()); //Do/while reads the values in row 3, i.e. "1", "2", "3"
    reader.ReadNext(); //Moves the reader to the start of row 4
    do
    {
        Console.WriteLine("Value at cell" + reader.Address);
        Console.WriteLine(reader.Value);
    } while(reader.ReadNextInRow()); //Reads the only value in row 4, e.g. "21:10"
    
    reader.ReadNext();
    while(reader.ReadNextInRow()); //Skips row 5    
}
*Disclaimer*: I'm the author of LightweightExcelReader.
