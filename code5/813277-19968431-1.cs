    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Calculator
    {
    public class Calculator
    {
    
        public Decimal displayValue;
        public Decimal currentValue;
        public Decimal Operand_1;
        public Decimal Operand_2;
        private bool Operand_1_Added = false;
        private bool Operand_2_Added = false;
          
         public void AddOperand(Decimal Operand)
        {
                if(Operand_1_Added) 
                    {
                      Operand_2 = Operand;
                      Operand_2_Added = true;
                    }
                else {
                      Operand_1 = Operand;
                      Operand_1_Added = true;
                     }
         }
         public void Add(Decimal Arg1, Decimal Arg2)
        {
    
            currentValue = Arg1 + Arg2;
    
        }
    
         public void Reciprocal(Decimal Arg)
     {
         currentValue = 1 / Arg;
     }
    
         public void Clear()
         {
             currentValue = 0;
             displayValue = 0;
             Operand_1 = 0;
             Operand_2 = 0;
         }
    
         public decimal CurrentValue
         {
           get
              {
               return currentValue;
              }
    
         }
    }
