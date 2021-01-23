    //Model class
    public class MathOperation
    {
        public Int32 Num { get; set; }
        public String Operation { get; set; }
    }
       String testData = "10+18+12-13";
       String[] GetNumbers = testData.Split(new Char[] { '+', '-' });
       String[] GetOperators = Regex.Split(testData, "[0-9]+");
       //remove empty entries in operator
       GetOperators = GetOperators.Where(x => !string.IsNullOrEmpty(x)).ToArray();
       List<MathOperation> list = new List<MathOperation>();
       MathOperation mathOperation = new MathOperation();
        for (int i = 0; i < GetNumbers.Count(); i++)
	{
           mathOperation.Num = Convert.ToInt32(GetNumbers[i]);               
           mathOperation.Operation = (i>GetOperators.Length)? GetOperators[i] : null;
           list.Add(mathOperation);
	}
