        public string GetData(int value)
        {            
            try
            {
                int i = 0;
                int y = 10/i;
                return string.Format("You entered: {0}", value);
            }
            catch (DivideByZeroException d)
            {
                throw new FaultException<DivideByZeroException>(d);
            }
        }
