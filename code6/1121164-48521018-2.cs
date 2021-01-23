         public class MyCustomNumericBox : System.Windows.Forms.NumericUpDown
        {
            public MyCustomNumericBox()
            {
               Controls.Remove(Controls[0]);
            }
        }
