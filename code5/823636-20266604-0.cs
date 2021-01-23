    public class MyClass {
        private mRbutton;
        public MyClass(RadioButton rbutton) {
            mRbutton = rbutton;
            // Rest of the construction code...
        }
        //
        // ... Rest of the class code ...
        //
        public void MessageShowingMethod() {
            if (mRbutton.IsChecked == true) {
                MessageBox.Show("Cancelled sending !");
            }
        }
    }
