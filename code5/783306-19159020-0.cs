    string a=string.Empty;
        StreamWriter yourStream = null;
        protected void Page_Load(object sender, EventArgs e)
        {
                yourStream = File.CreateText("D:\\test1.txt"); // creating file
                a = String.Format("|{0,1}|{1,2}|{2,7}|......", "A", "B", "",......); //formatting text based on poeition
                yourStream.Write(a+"\r\n");                        
                yourStream.Close();
            }
