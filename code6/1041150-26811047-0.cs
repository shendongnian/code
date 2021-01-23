    namespace WindowsFormsApplication3
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            TextBox textBox;
            SomeClass someClass;
    
            public Form1()
            {
                InitializeComponent();
                Initialize();
                BindComponents();
            }
    
            private void BindComponents()
            {
                //EventHandlers
                this.Load += new EventHandler(Form1_Load);
                this.someClass.TextUpdatedEvent += new EventHandler(someClass_TextUpdatedEvent);
            }
    
            void someClass_TextUpdatedEvent(object sender, EventArgs e)
            {
                this.textBox.Text = (e as FormArgs).Text;
            }
    
            private void Initialize()
            {
                this.textBox = new TextBox();
                this.someClass = new SomeClass();
            }
    
            void Form1_Load(object sender, EventArgs e)
            {
                this.Controls.Add(textBox);
            }
        }
    
        public class SomeClass
        {
            public event EventHandler TextUpdatedEvent = delegate { };
    
            public void UpdateText(string text)
            {
                if (TextUpdatedEvent != null)
                {
                    TextUpdatedEvent(this, new FormArgs() { Text = text });
                }
            }
        }
    
        public class FormArgs : EventArgs
        {
            public string Text { get; set; }
        }
    }
