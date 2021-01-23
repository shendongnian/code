    public class Form1 : Form
    {
        private string[] userNames;
        public Form1()
        {
            string path = "http://mywebsite.com/accounts.txt";
            userNames = File.ReadAllLines(path);
        }
    }
