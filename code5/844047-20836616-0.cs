    public class CalcTest
    { 
        public string[] uniform(string[] numbers)
        {
            Regex re = new Regex("[^0-9]");
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].Replace(" ", "");
                number = re.Replace(number, ".", numbers[i].Length);
                numbers[i] = number;
            }
 
            return numbers;
        }
    }
