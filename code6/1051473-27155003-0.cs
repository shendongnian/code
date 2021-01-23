        public class MyClass
        {
                private int handle;
                private void button1_Click(object sender, EventArgs e)
                {
                    handle = 0;
                }
        
                private void button2_Click(object sender, EventArgs e)
                {
                    GetHandle();
                }
        
                private int GetHandle()
                {
                    return handle;
                }
        }
