    using System;
    using System.Collections.Generic;
    public class Card
    {
        protected Dictionary<string, int> ValidFaceValues;
        
        private string FaceValue;
        
        public Card(string FaceValue)
        {
            ValidFaceValues = new Dictionary<string, int>();
            ValidFaceValues.Add("J", 11);
            ValidFaceValues.Add("Q", 12);
            ValidFaceValues.Add("K", 13);
            
            if(ValidFaceValues.ContainsKey(FaceValue))
            {
                this.FaceValue = FaceValue;
            }
            else
            {
                throw new Exception();
            }
        }
        
        public int GetValue()
        {
            int value = 0;
            ValidFaceValues.TryGetValue(FaceValue, out value);
            return value;
        }
    }
    public class BlackJackCard : Card
    {
        public BlackJackCard()
        {
            ValidFaceValues = new Dictionary<string, int>();
            ValidFaceValues.Add("J", 10);
            ValidFaceValues.Add("Q", 10);
            ValidFaceValues.Add("K", 10);
            
            if(ValidFaceValues.ContainsKey(FaceValue))
            {
                this.FaceValue = FaceValue;
            }
            else
            {
                throw new Exception();
            }
        }
    }
