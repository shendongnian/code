    class Program
    {
        static void Main(string[] args)
        {
            var dice = new List<DiceLogic>();
            int a = 0;
            int times = GetTimes();
            while (a != times)
            {
                int antThrow = GetAntThrow();
                int xChoice = GetXChoice();
                int yChoice = GetYChoice();
                dice.Add(new DiceLogic(xChoice, yChoice, antThrow));
                a++;
            }
            int e = 1;
            foreach (var item in dice)
            {
                Console.WriteLine("Result of game {0}: {1}", e++, item.Tostring());
            }
            Console.ReadLine();
        }
        private static int GetTimes()
        {
            while (true)
            {
                Console.WriteLine("Write how many times you want to repeat the game:");
                int times;
                var result = int.TryParse(Console.ReadLine(), out times);
                if (result) return times;
                Console.WriteLine("Value must be a number.");
            }
        }
        private static int GetAntThrow()
        {
            while (true)
            {
                Console.WriteLine("Write how many times you want each dice to get thrown:");
                int antThrow;
                var result = int.TryParse(Console.ReadLine(), out antThrow);
                if (result) return antThrow;
                Console.WriteLine("Value must be a number.");
            }
        }
        private static int GetXChoice()
        {
            while (true)
            {
                Console.WriteLine("Write how many dice you want to throw:");
                int getXChoice;
                var result = int.TryParse(Console.ReadLine(), out getXChoice);
                if (result) return getXChoice;
                Console.WriteLine("Value must be a number.");
            }
        }
        private static int GetYChoice()
        {
            while (true)
            {
                Console.WriteLine("Write how many sides you want each dice should have:");
                int getXChoice;
                var result = int.TryParse(Console.ReadLine(), out getXChoice);
                if (result) return getXChoice;
                Console.WriteLine("Value must be a number.");
            }
        }
    }
    public class DiceLogic
    {
        public string Tostring()
        {
            int maxScore = _diceSides*_dices;
            if (_result >= maxScore / 2)
            {
                return "Good throw! " + _result;
            }
            return "Bad throw! " + _result;
        }
        private readonly int _dices;
        private readonly int _diceSides;
        private readonly int _throwDice;
        private int _result;
        private void CalculateResult()
        {
            var rnd = new Random();
            for (int i = 0; i < _dices; i++)
            {
                int currentResult = 0;
                for (int j = 0; j < _throwDice; j++)
                {
                    currentResult = rnd.Next(0, _diceSides);
                }
                _result += currentResult;
            }
        }
        public DiceLogic(int dices, int diceSides, int throwEachDice)
        {
            _dices = dices;
            _diceSides = diceSides;
            _throwDice = throwEachDice;
            CalculateResult();
        }
    }
