    string[] inputstrings = { "ComputerPart", "topaz", "questions" };//An array of input strings to manipulate.
    string output = "";
    Regex rgx = new Regex("t");//Regex pattern to match occurence of 't'.
    foreach (string inputstring in inputstrings)//Iterate through each string in collection.
    {
      output = rgx.Replace(inputstring, "success", int.MaxValue, 1);//Replace each occurence of 't' excluding those occurring at position [0] in inputstring.
      MessageBox.Show(output);//Show output string.
    }
