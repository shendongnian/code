        char[][] numbers = new char[][]
        {
            "0123456789".ToCharArray(),"persian numbers 0-9 here".ToCharArray()
        };
        public void Convert(string problem)
        {
            for (int x = 0; x <= 9; x++)
            {
                problem.Replace(numbers[0][x], numbers[1][x]);
            }
        }
