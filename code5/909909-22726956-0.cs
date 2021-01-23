    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public class Calculator
        {
            public Calculator(string displayValue)
            {
                decimal currentValue = Decimal.Parse(displayValue);
            }
        }
    }
