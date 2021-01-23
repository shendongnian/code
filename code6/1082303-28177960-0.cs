    class MessageType {
        public enum MessageTypeEnum {
            get, 
            set, 
            identify
        }
        public static MessageTypeEnum getLogicalValue (byte numericalValue)
        {
           if (numericalValue == 0x00) 
              return MessageTypeEnum.get; 
           else if (numericalValue == 0x01)
              return MessageTypeEnum.set;
           else
              return MessageTypeEnum.identify;
        }
    }
