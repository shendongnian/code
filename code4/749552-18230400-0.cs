    private void ReduceTo1(int input, ref int totalCount)
            {
                totalCount++;
                if (input % 2 == 0)
                {
                    input = input / 2;
                }
                else
                {
                    input = input * 3 + 1;
                }
                if (input != 1)
                    ReduceTo1(input, ref totalCount);               
    
            }
