    private void button1_Click(object sender, EventArgs e)
    {
        var o = new x ();
        string s = "ff" + o;
            
        Console.WriteLine(s);
           
    }
    public class x {
        public override string ToString()
        {
            return "This is string";
        }
    }
