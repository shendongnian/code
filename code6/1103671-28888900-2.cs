    public Form1()
        {
            InitializeComponent();
            string content = "";
            using (FileStream fs = new FileStream("D:\\names.txt", FileMode.Open, FileAccess.Read)) 
                using (StreamReader sr = new StreamReader(fs))
                content = sr.ReadToEnd();
            string[] names = content.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string path = "D:\\RandDirs";
            if (!Directory.Exists(path))Directory.CreateDirectory(path) ;
            for (int i = 0; i < 50; i++) Directory.CreateDirectory(path + "\\" + getRandomName(names));
        }
        Random randName = new Random();
        Random insertingNumber = new Random();
        Random randUpper = new Random();
        Random randInsertNumber = new Random();
        string getRandomName(string[] names)
        {
            string name = names[randName.Next(names.Length)];
            name = name.Replace(" ", "");
            string result = "";
            
            for (int i = 0; i < name.Length; i++)
                result += (randUpper.Next(0, 9) <= 5 ? name[i].ToString().ToLower() : name[i].ToString().ToUpper())
                + (((i + 1) % 2 == 0) ? insertingNumber.Next(0, 9).ToString() : "");
            return result;
        }
