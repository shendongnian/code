    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace WindowsFormsApplication1
    {
        public class MyModelClass : System.ComponentModel.INotifyPropertyChanged
        {
            private System.Drawing.Color _aColor;
    
            public System.Drawing.Color AColor
            {
                get { return _aColor; }
                set { 
                    _aColor = value;
                    fireChanged("AColor");
                }
            }
    
            private System.Drawing.Color _anotherColor;
    
            public System.Drawing.Color AnotherColor
            {
                get { return _anotherColor; }
                set { 
                    _anotherColor = value;
                    fireChanged("AnotherColor");
                }
            }
    
            public void doSomething() 
            {
                //some function here
                System.Windows.Forms.MessageBox.Show("doSomething() was called"); 
            }
    
            private void fireChanged(string name)
            {
                var evth = PropertyChanged;
                if (evth != null)
                    evth(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
    
            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        }
    }
