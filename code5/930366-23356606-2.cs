    class Form2: System.Windows.Forms.Form, IOutsideCallable
    {
        // other form code
     
        public void PerformButtonClick()
        {
            btn_Click(null, null);
        }
    }
