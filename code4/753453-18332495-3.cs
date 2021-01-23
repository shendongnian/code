    public static class myMethods
    {
        public static void getName(out string name){  
          //.....
        }
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        string name;
        myMethods.getName(out name);
        textBox1.Text = name;
    }
