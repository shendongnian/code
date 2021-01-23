    private void button1_Click(object sender, EventArgs e)
    {
        byte[] result = textBox1.Text.Encrypt();
    }
    public class Extensionmethods
    {
        public static byte[] Encrypt(this string TextValue)
        {
            //Your code here
        }
    }
