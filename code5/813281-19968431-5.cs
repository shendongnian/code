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
        private Decimal Operand_1;
        private Decimal Operand_2;
        private bool Operand_1_Added = false;
        private bool Operand_2_Added = false;
        private string Operation = "";
          
       private void AddOperand(Decimal Operand)
        {
                if(Operand_1_Added) 
                    {
                      Operand_2 = Operand;
                      Operand_2_Added = true;
                    }
                else {
                      Operand_1 = Operand;
                      Operand_1_Added = true;
                      currentValue = Operand_1;
                     }
         }
       public void Add(Decimal Arg1)
        {  
            this.AddOperand(Arg1);
            Operation = "Addition";
        }
    
       public void Reciprocal(Decimal Arg)
        {
         this.AddOperand(Arg);
         Operation = "Reciprocal";
        }
    
         public void Clear()
         {
             currentValue = 0;
             displayValue = 0;
             Operand_1 = 0;
             Operand_2 = 0;
         }
    
         public void Equals()
          {
             switch(Operation)
                 {
                     case "Addition": 
                              currentValue = Operand_1 + Operand_2
                              break;
                     case "Reciprocal"
                              currentValue = 1/Operand_1;
                              break;
                     default: break; 
                  }
          }
       public void Equal(Decimal displayValue)
       {
        currentValue = displayValue;
       }
         public decimal CurrentValue
         {
           get
              {
               return currentValue;
              }
    
         }
    }
