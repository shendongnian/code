public void PrintDocument(string textName)
{
  PrinterFont = new Font("Verdana", 10);
  TextToPrint = textName; // No longer trying to magically access field
  Print();
}
