        public static string getLogicalValue(byte numericalValue)
        {
            Type type = numericalValue.GetType();
            var name = Enum.GetName(typeof(MessageTypeEnum), numericalValue);
            switch(numericalValue)
            {
                case 0x00:
                    {
                        name= (MessageTypeEnum.get.ToString());
                        break;
                    }
                case 0x01:
                    {
                        name= (MessageTypeEnum.set.ToString());
                        break;
                    }
                    
                case 0x02:
                case 0xff:
                    {
                        name= (MessageTypeEnum.identify.ToString());
                        break;
                    }
            }
            return name;
        }
 
