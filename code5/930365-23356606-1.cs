    class Form1: System.Windows.Forms.Form
    {
        // form1 code
    
        pubic IOutsideCallable Form2Variable {get; set; }
    
        void foo() // the function in which you will invoke the button click of Form2
        {
             if(Form2Variable != null)
                 Form2Variable.PerformButtonClick();
        }
    }
