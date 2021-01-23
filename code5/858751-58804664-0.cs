    private int LuhnChecksum(string input)
        {
            var length = input.Length; 
            var even = length % 2; 
            var sum = 0;
            for (var i = length - 1; i >= 0; i--)  
            {
                var d = int.Parse(input[i].ToString());
                if (i % 2 == even)
                    d *= 2;
                if (d > 9)
                    d -= 9;
                sum += d;
            }
            return sum % 10;
        }
        private int LuhnCalculateLastDigit(string input) 
        {
            var checksum = LuhnChecksum(input + "0");
            return checksum == 0 ? 0 : 10 - checksum;
        }
