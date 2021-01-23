    public Form1() {
        InitializeComponent();
        // you have to create an instance of foo first:
        var f = new foo();
        for (int x = 0; x <= 8939500; x++) {
            // and access the fileuser through that instance of foo
            lineuser = f.fileuser.ReadLine();                //The error line
            if (!string.IsNullOrEmpty(lineuser)) {
                string[] values = lineuser.Split(' ');
                int userid, factoriduser;
                foreach (string value in values){
                    ........
