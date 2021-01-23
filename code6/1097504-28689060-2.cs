    namespace Test
    {
        enum SpecialValue
        {
            Zero = 0,
            Five = 5,
            Seventy = 70
        }
    
        private void method()
        {
            var five = (SpecialValue)5; // == SpecialValue.Five
            int seventy = (int)SpecialValue.Seventy; // == 70
        }
    }
